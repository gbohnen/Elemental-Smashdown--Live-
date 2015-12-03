using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {

    public static int cardsRemaining;

    public Sprite cardBack;
    public Sprite cardFront;
    public Sprite fire_beelzebub;
    public Sprite fire_fireAnt;
    public Sprite fire_fireElemental;
    public Sprite fire_magmaMasher;
    public Sprite fire_phoenix;
    public Sprite fire_salamander;
    public Sprite grass_bengalTiger;
    public Sprite grass_giantCaterpillar;
    public Sprite grass_grassElemental;
    public Sprite grass_unicorn;
    public Sprite grass_venusSnapdragon;
    public Sprite grass_vineSnake;
    public Sprite neutral_grandpaTim;
    public Sprite neutral_mechanicalMan;
    public Sprite water_giantTortoise;
    public Sprite water_lochNessMonster;
    public Sprite water_merman;
    public Sprite water_poseidon;
    public Sprite water_waterElemental;
    public Sprite water_waterStrider;

    public Sprite[] numberSprites;

    // prefabs
    public GameObject prefabSprite;
    public GameObject prefabCard;

    public List<string> cardNames;
    public List<Vector3> cardStats;
    public List<Card> cards;
    public Transform deckAnchor;
    public List<Sprite> cardSprites;


    // make the card gameobjects
    public void InitDeck()
    {
        // creates an anchor for all the card gameobjects
        if (GameObject.Find("Deck") == null)
        {
            GameObject anchorGO = new GameObject("Deck");
            deckAnchor = anchorGO.transform;
        }

        // cardnames will be the names to build
        cardNames = new List<string>();
        cardStats = new List<Vector3>();
        cardSprites = new List<Sprite>();

        // add names
        cardNames.Add("Beelzebub");
        cardNames.Add("Fire Elemental");
        cardNames.Add("Salamander");
        cardNames.Add("Fire Ant");
        cardNames.Add("Magma Masher");
        cardNames.Add("Phoenix");
        cardNames.Add("Poseidon");
        cardNames.Add("Water Elemental");
        cardNames.Add("Giant Tortoise");
        cardNames.Add("Mermaid");
        cardNames.Add("Loch Ness Monster");
        cardNames.Add("Water Strider");
        cardNames.Add("Venus Snapdragon");
        cardNames.Add("Grass Elemental");
        cardNames.Add("Unicorn");
        cardNames.Add("Bengal Tiger");
        cardNames.Add("Vine Snake");
        cardNames.Add("Giant Caterpillar");
        cardNames.Add("Grandpa Tim");
        cardNames.Add("Mechanical Man");

        // add stats
        cardStats.Add(new Vector3(8, 1, 3));
        cardStats.Add(new Vector3(4, 3, 3));
        cardStats.Add(new Vector3(5, 3, 4));
        cardStats.Add(new Vector3(3, 2, 3));
        cardStats.Add(new Vector3(7, 2, 1));
        cardStats.Add(new Vector3(6, 2, 2));
        cardStats.Add(new Vector3(1, 8, 3));
        cardStats.Add(new Vector3(3, 4, 3));
        cardStats.Add(new Vector3(2, 6, 2));
        cardStats.Add(new Vector3(3, 5, 4));
        cardStats.Add(new Vector3(1, 7, 2));
        cardStats.Add(new Vector3(2, 3, 3));
        cardStats.Add(new Vector3(1, 3, 8));
        cardStats.Add(new Vector3(3, 4, 5));
        cardStats.Add(new Vector3(2, 1, 7));
        cardStats.Add(new Vector3(2, 2, 6));
        cardStats.Add(new Vector3(3, 3, 4));
        cardStats.Add(new Vector3(2, 3, 3));
        cardStats.Add(new Vector3(3, 2, 2));
        cardStats.Add(new Vector3(4, 4, 4));

        // add sprites
        cardSprites.Add(fire_beelzebub);
        cardSprites.Add(fire_fireElemental);
        cardSprites.Add(fire_salamander);
        cardSprites.Add(fire_fireAnt);
        cardSprites.Add(fire_magmaMasher);
        cardSprites.Add(fire_phoenix);        
        cardSprites.Add(water_poseidon);        
        cardSprites.Add(water_waterElemental);
        cardSprites.Add(water_giantTortoise);
        cardSprites.Add(water_merman);
        cardSprites.Add(water_lochNessMonster);
        cardSprites.Add(water_waterStrider);        
        cardSprites.Add(grass_venusSnapdragon);
        cardSprites.Add(grass_grassElemental);
        cardSprites.Add(grass_unicorn);
        cardSprites.Add(grass_bengalTiger);
        cardSprites.Add(grass_vineSnake);
        cardSprites.Add(grass_giantCaterpillar);
        cardSprites.Add(neutral_grandpaTim);
        cardSprites.Add(neutral_mechanicalMan);
        

        // add the cards
		for (int j = 0; j < 3; j++) 
		{
			for (int i = 0; i < 20; i++)
			{
				GameObject temp = Instantiate (prefabCard);          
            
				// build card
				temp.GetComponent<Card> ().stats = cardStats [i];
				temp.GetComponent<Card> ().sprite = cardSprites [i];
				temp.GetComponent<Card> ().cardName = cardNames [i];
				temp.GetComponent<Card> ().flipped = true;
				temp.GetComponent<Card> ().back = cardBack;

				// position card
				temp.transform.position = deckAnchor.position;
				temp.transform.rotation = deckAnchor.rotation;
				temp.transform.localScale = deckAnchor.localScale;

				cards.Add (temp.GetComponent<Card> ());
			}
		}

        ShuffleDeck();

        cardsRemaining = cards.Count;
    }

    public void Update()
    {
        cardsRemaining = cards.Count;
    }

    public Card GetNextCard()
    {
        if (cardsRemaining > 0)
        {
            Card temp = cards[0];
            cards.RemoveAt(0);

            temp.flipped = false;

            return temp;
        }
        else
        {
            return null;
        }
        
    }

    public void ShuffleDeck()
    {
        List<Card> tempList = new List<Card>(cards.Count);

        for (int i = cards.Count; i > 0; i--)
        {
            int temp = (int)Random.Range(0, cards.Count);
            tempList.Add(cards[temp]);
            cards.RemoveAt(temp);
        }

        cards = tempList;

    }
}
