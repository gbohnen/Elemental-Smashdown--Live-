using UnityEngine;    // For Debug.Log, etc.

using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System;
using System.Runtime.Serialization;
using System.Reflection;

// === This is the info container class ===
[Serializable()]
public class SaveData : ISerializable
{

    // === Values ===
    // Edit these during gameplay
    public PlayerTurn whichTurn = PlayerTurn.Player1;

    public Card player1card;
    public Card player2card;

    public bool player1selected = false;
    public bool player2selected = false;

    public Card[] player1Hand = new Card[5];
    public Card[] player2Hand = new Card[5];
    // === /Values ===

    // The default constructor. Included for when we call it during Save() and Load()
    public SaveData() 
    {
        PlayerController controller = GameObject.FindGameObjectWithTag("controller").GetComponent<PlayerController>();

        //whichTurn = PlayerController.whichTurn;
        player1card = controller.player1card;
        player2card = controller.player2card;
        player1selected = controller.player1selected;
        player2selected = controller.player2selected;
        player1Hand = controller.player1Hand;
        player2Hand = controller.player2Hand;

    }

    public SaveData(PlayerTurn whichTurn, Card player1card, Card player2card, bool player1selected, bool player2selected, Card[] player1Hand, Card[] player2Hand)
    {
        this.whichTurn = whichTurn;
        this.player1card = player1card;
        this.player2card = player2card;
        this.player1selected = player1selected;
        this.player2selected = player2selected;
        this.player1Hand = player1Hand;
        this.player2Hand = player2Hand;
    }

    // This constructor is called automatically by the parent class, ISerializable
    // We get to custom-implement the serialization process here
    public SaveData(SerializationInfo info, StreamingContext ctxt)
    {
        // Get the values from info and assign them to the appropriate properties. Make sure to cast each variable.
        // Do this for each var defined in the Values section above
        whichTurn = (PlayerTurn)info.GetValue("whichTurn", typeof(PlayerTurn));

        player1card = (Card)info.GetValue("player1card", typeof(Card));
        player2card = (Card)info.GetValue("player2card", typeof(Card));

        player1selected = (bool)info.GetValue("player1selected", typeof(bool));
        player2selected = (bool)info.GetValue("player2selected", typeof(bool));

        player1Hand = (Card[])info.GetValue("player1Hand", typeof(Card[]));
        player2Hand = (Card[])info.GetValue("player2Hand", typeof(Card[]));
    }

    // Required by the ISerializable class to be properly serialized. This is called automatically
    public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
    {
        // Repeat this for each var defined in the Values section
        info.AddValue("whichTurn", (whichTurn));

        info.AddValue("player1card", (player1card));
        info.AddValue("player2card", (player2card));

        info.AddValue("player1selected", (player1selected));
        info.AddValue("player2selected", (player2selected));

        info.AddValue("player1Hand", (player1Hand));
        info.AddValue("player2Hand", (player2Hand));
    }
}

// === This is the class that will be accessed from scripts ===
public class SaveLoad
{

    public static string currentFilePath = "SaveData.cjc";    // Edit this for different save files

    // Call this to write data
    public static void Save()  // Overloaded
    {
        Save(currentFilePath);
    }
    public static void Save(string filePath)
    {
        Debug.Log("Saving...");
        SaveData data = new SaveData();

        Stream stream = File.Open(filePath, FileMode.Create);
        BinaryFormatter bformatter = new BinaryFormatter();
        bformatter.Binder = new VersionDeserializationBinder();
        bformatter.Serialize(stream, data);
        stream.Close();
    }

    // Call this to load from a file into "data"
    public static void Load() { Load(currentFilePath); }   // Overloaded
    public static void Load(string filePath)
    {
        Debug.Log("Loading...");
        SaveData data = new SaveData();
        Stream stream = File.Open(filePath, FileMode.Open);
        BinaryFormatter bformatter = new BinaryFormatter();
        bformatter.Binder = new VersionDeserializationBinder();
        data = (SaveData)bformatter.Deserialize(stream);
        stream.Close();

        // Now use "data" to access your Values
    }

}

// === This is required to guarantee a fixed serialization assembly name, which Unity likes to randomize on each compile
// Do not change this
public sealed class VersionDeserializationBinder : SerializationBinder
{
    public override Type BindToType(string assemblyName, string typeName)
    {
        if (!string.IsNullOrEmpty(assemblyName) && !string.IsNullOrEmpty(typeName))
        {
            Type typeToDeserialize = null;

            assemblyName = Assembly.GetExecutingAssembly().FullName;

            // The following line of code returns the type. 
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));

            return typeToDeserialize;
        }

        return null;
    }
}