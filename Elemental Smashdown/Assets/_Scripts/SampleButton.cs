using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class SampleButton : MonoBehaviour {

    public Button button;
    public Text characterName;
    public Text fireStat;
    public Text waterStat;
    public Text grassStat;
    public Sprite cardSprite;

    public GameObject cardPrefab;

    public void Update()
    {
        if (!PlayerController.instance.hasResed)
        {
            // check if there is space in the active players hand
            if (PlayerController.whichTurn == PlayerTurn.Player1)
                button.interactable = PlayerController.instance.player1space;
            else
                button.interactable = PlayerController.instance.player2space;
        }
        else
            button.interactable = false;
    }

    public void AddCard()
    {
        if (PlayerController.whichTurn == PlayerTurn.Player1)
        {
            for (int i = 0; i < 5; i++)
            {
                if (PlayerController.instance.player1Hand[i].dead)
                {
                    // destroy the old card
                    Destroy(PlayerController.instance.player1Hand[i].gameObject);

                    // build the new card
                    GameObject temp = Instantiate(cardPrefab) as GameObject;
                    temp.GetComponent<Card>().stats = new Vector3(float.Parse(fireStat.text), float.Parse(waterStat.text), float.Parse(grassStat.text));
                    temp.GetComponent<Card>().sprite = cardSprite;
                    temp.GetComponent<Card>().cardName = characterName.text;
                    temp.GetComponent<Card>().flipped = false;
                    temp.GetComponent<Card>().belongsTo = PlayerTurn.Player1;
                    temp.transform.position = new Vector3(4 * i - 5, 5, 0);

                    // add the card to the hand
                    PlayerController.instance.player1Hand[i] = temp.GetComponent<Card>();

                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                if (PlayerController.instance.player2Hand[i].dead)
                {
                    // destroy the old card
                    Destroy(PlayerController.instance.player2Hand[i].gameObject);

                    // build the new card
                    GameObject temp = Instantiate(cardPrefab) as GameObject;
                    temp.GetComponent<Card>().stats = new Vector3(float.Parse(fireStat.text), float.Parse(waterStat.text), float.Parse(grassStat.text));
                    temp.GetComponent<Card>().sprite = cardSprite;
                    temp.GetComponent<Card>().cardName = characterName.text;
                    temp.GetComponent<Card>().flipped = false;
                    temp.GetComponent<Card>().belongsTo = PlayerTurn.Player2;
                    temp.transform.position = new Vector3(4 * i - 5, -5, 0);

                    // add the card to the hand
                    PlayerController.instance.player2Hand[i] = temp.GetComponent<Card>();

                    break;
                }
            }
        }

        PlayerController.instance.hasResed = true;

        NotificationList.instance.AddItem(PlayerController.whichTurn.ToString() + " resurrects " + characterName.text + "!");

        // destroy the button
        Destroy(gameObject);
    }
}
