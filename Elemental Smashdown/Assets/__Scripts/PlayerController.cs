using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    public static PlayerTurn whichTurn = PlayerTurn.Player1;

    public GameObject indicatorPrefab;

    public Card player1card;
    public Card player2card;

    public bool player1selected = false;
    public bool player2selected = false;

    public Card[] player1Hand;
    public Card[] player2Hand;

    public ActiveIndicator[] player1Indicators;
    public ActiveIndicator[] player2Indicators;

	// Use this for initialization
	void Start () {

        player1Hand = new Card[5];
        player2Hand = new Card[5];

        Deck deck = GameObject.FindGameObjectWithTag("Deck").GetComponent<Deck>();
        deck.InitDeck();

        for (int i = 0; i < 5; i++)
        {
            player1Hand[i] = deck.GetNextCard();
            player1Hand[i].flipped = false;
            player1Hand[i].belongsTo = PlayerTurn.Player1;

            player2Hand[i] = deck.GetNextCard();
            player2Hand[i].flipped = false;
            player2Hand[i].belongsTo = PlayerTurn.Player2;            
        }

        RotateCards();
        ChangeBackground();
        ChangeBackground();

        // indicator code
        player1Indicators = new ActiveIndicator[5];
        player2Indicators = new ActiveIndicator[5];
        
        GameObject temp = Instantiate(indicatorPrefab);
        
        for (int i = 0; i < 5; i++)
        {
            player1Indicators[i] = temp.GetComponent<ActiveIndicator>();
            player2Indicators[i] = Instantiate(indicatorPrefab).GetComponent<ActiveIndicator>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        Draw();

        if (Player1Score.player1score >= 20)
        {
            SoundManager.instance.PlaySound("win", 1f);
            Application.LoadLevel("Player1Win");
        }

        if (Player2Score.player2score >= 20)
        {
            SoundManager.instance.PlaySound("win", 1f);
            Application.LoadLevel("Player2Win");
        }
	}

    void Draw()
    {
        player1Hand[0].transform.position = new Vector3(-8, 5, 0);
        player1Hand[1].transform.position = new Vector3(-4, 5, 0);
        player1Hand[2].transform.position = new Vector3(0, 5, 0);
        player1Hand[3].transform.position = new Vector3(4, 5, 0);
        player1Hand[4].transform.position = new Vector3(8, 5, 0);

        player2Hand[0].transform.position = new Vector3(-8, -5, 0);
        player2Hand[1].transform.position = new Vector3(-4, -5, 0);
        player2Hand[2].transform.position = new Vector3(0, -5, 0);
        player2Hand[3].transform.position = new Vector3(4, -5, 0);
        player2Hand[4].transform.position = new Vector3(8, -5, 0);
    }

    void RotateCards()
    {
        for (int i = 0; i < 5; i++)
        {
            player1Hand[i].transform.Rotate(new Vector3(0, 0, 90));
            player2Hand[i].transform.Rotate(new Vector3(0, 0, 90));
        }
    }

    public void SelectCard(Card temp)
    {


        // select cards logic
        if (temp.belongsTo == PlayerTurn.Player1 && player1selected == false && temp.selected == false && temp.attacked == false && !temp.flipped)
        {
			StartCoroutine(ScaleUpOverTime(temp, .2f));
			//temp.transform.localScale += new Vector3((float)0.40, (float)0.40, 0);
            temp.selected = true;
            player1selected = true;
            player1card = temp;

            SoundManager.instance.PlaySound("selectUp", .5f);
        }
		else if (temp.belongsTo == PlayerTurn.Player1 && player1selected == true && temp.selected == true && temp.attacked == false && !temp.flipped)
        {
			StartCoroutine(ScaleDownOverTime(temp, .2f));
            //temp.transform.localScale -= new Vector3((float)0.40, (float)0.40, 0);
            temp.selected = false;
            player1selected = false;
            player1card = null;

            SoundManager.instance.PlaySound("selectDown", .5f);
        }
		else if (temp.belongsTo == PlayerTurn.Player2 && player2selected == false && temp.selected == false && temp.attacked == false && !temp.flipped)
        {
			StartCoroutine(ScaleUpOverTime(temp, .2f));
            //temp.transform.localScale += new Vector3((float)0.40, (float)0.40, 0);
            temp.selected = true;
            player2selected = true;
            player2card = temp;

            SoundManager.instance.PlaySound("selectUp", .5f);
        }
		else if (temp.belongsTo == PlayerTurn.Player2 && player2selected == true && temp.selected == true && temp.attacked == false && !temp.flipped)
        {
			StartCoroutine(ScaleDownOverTime(temp, .2f));
            //temp.transform.localScale -= new Vector3((float)0.40, (float)0.40, 0);
            temp.selected = false;
            player2selected = false;
            player2card = null;

            SoundManager.instance.PlaySound("selectDown", .5f);
        }

        // call the fight method
        if (player1selected && player2selected)
        {
            Fight(player1card, player2card);

            // set cards as attacked
            player1card.attacked = true;
            player2card.attacked = true;

            // reset cards
			player1card.transform.localScale -= new Vector3((float)0.40, (float)0.40, 0);
            player2card.transform.localScale -= new Vector3((float)0.40, (float)0.40, 0);
            player1card.selected = false;
            player2card.selected = false;
            player1selected = false;
            player2selected = false;
            player1card = null;
            player2card = null;
        }
    }

	IEnumerator ScaleUpOverTime(Card temp, float time)
	{
		// set the current size and target size
		Vector3 originalScale = new Vector3(1.275017f, 1.275017f, 1);
		Vector3 destinationScale = new Vector3 (1.638793f, 1.638793f, 1);
		
		// zero the time
		float currentTime = 0.0f;
		
		do
		{
			// scale up and increase time each frame
			temp.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);
	}

	IEnumerator ScaleDownOverTime(Card temp, float time)
	{
		// set the current size and target size
		Vector3 originalScale = new Vector3 (1.638793f, 1.638793f, 1);
		Vector3 destinationScale = new Vector3(1.275017f, 1.275017f, 1);
		
		// zero the time
		float currentTime = 0.0f;
		
		do
		{
			// scale up and increase time each frame
			temp.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);
	}

	IEnumerator FlipCard(Card temp, float time)
	{
		// set the current size and target size
		Vector3 originalScale = new Vector3 (1.275017f, 1.275017f, 1);
		Vector3 destinationScale = new Vector3(0, 1.275017f, 1);
		
		// zero the time
		float currentTime = 0.0f;
		
		do
		{
			// scale up and increase time each frame
			temp.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);
		
		temp.flipped = !temp.flipped;
		
		// zero the time
		currentTime = 0.0f;
		
		do
		{
			// scale up and increase time each frame
			temp.transform.localScale = Vector3.Lerp(destinationScale, originalScale, currentTime / time);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);
		
	}

    public void Fight(Card player1, Card player2)
    {
        // fight in fire
        if (Background.currentType == BackgroundType.Fire)
        {
            if (player1card.stats.x > player2card.stats.x)
            {
                player2card.dead = true;
                Player1Score.player1score++;
                FightSound(PlayerTurn.Player1);
            }
            else if (player1card.stats.x < player2card.stats.x)
            {
                player1card.dead = true;
                Player2Score.player2score++;
                FightSound(PlayerTurn.Player2);
            }
            else if (player1card.stats.x == player2card.stats.x)
            {
                player2card.dead = true;
                Player1Score.player1score++;
                player1card.dead = true;
                Player2Score.player2score++;
            }
        }
        // fight in grass
        else if (Background.currentType == BackgroundType.Water)
        {
            if (player1card.stats.y > player2card.stats.y)
            {
                player2card.dead = true;
                Player1Score.player1score++;
                FightSound(PlayerTurn.Player1);
            }
            else if (player1card.stats.y < player2card.stats.y)
            {
                player1card.dead = true;
                Player2Score.player2score++;
                FightSound(PlayerTurn.Player2);
            }
            else if (player1card.stats.y == player2card.stats.y)
            {
                player2card.dead = true;
                Player1Score.player1score++;
                player1card.dead = true;
                Player2Score.player2score++;
            }
        }
        // fight in water
        else if (Background.currentType == BackgroundType.Grass)
        {
            if (player1card.stats.z > player2card.stats.z)
            {
                player2card.dead = true;
                Player1Score.player1score++;
                FightSound(PlayerTurn.Player1);
            }
            else if (player1card.stats.z < player2card.stats.z)
            {
                player1card.dead = true;
                Player2Score.player2score++;
                FightSound(PlayerTurn.Player2);
            }
            else if (player1card.stats.z == player2card.stats.z)
            {
                player2card.dead = true;
                Player1Score.player1score++;
                player1card.dead = true;
                Player2Score.player2score++;
            }
        }
		MovesRemaining.movesLeft--;
    }
    public void ResetBoard()
    {
        for (int i = 0; i < 5; i++)
        {
            if (player1Hand[i].dead == true)
            {
                Deck deck = GameObject.FindGameObjectWithTag("Deck").GetComponent<Deck>();
				Destroy(player1Hand[i].gameObject);
                player1Hand[i] = deck.GetNextCard();
				player1Hand[i].flipped = true;
                StartCoroutine(ChangePosition(player1Hand[i], .5f, new Vector3(4 * i - 8, 5, 0)));
				StartCoroutine(FlipCard(player1Hand[i], .5f));
                //player1Hand[i].flipped = false;
                player1Hand[i].selected = false;
                player1Hand[i].dead = false;
                player1Hand[i].belongsTo = PlayerTurn.Player1;
                player1Hand[i].transform.Rotate(new Vector3(0, 0, 90));
            }

            if (player2Hand[i].dead == true)
            {
                Deck deck = GameObject.FindGameObjectWithTag("Deck").GetComponent<Deck>();
				Destroy(player2Hand[i].gameObject);
                player2Hand[i] = deck.GetNextCard();
				player2Hand[i].flipped = true;
                StartCoroutine(ChangePosition(player2Hand[i], .5f, new Vector3(4 * i - 8, -5, 0)));
				StartCoroutine(FlipCard(player2Hand[i], .5f));
                //player2Hand[i].flipped = false;
                player2Hand[i].selected = false;
                player2Hand[i].dead = false;
                player2Hand[i].belongsTo = PlayerTurn.Player2;
                player2Hand[i].transform.Rotate(new Vector3(0, 0, 90));
            }

			if (player1Hand[i].selected == true)
			{
				StartCoroutine(ScaleDownOverTime(player1Hand[i], .1f));
			}

			if (player2Hand[i].selected == true)
			{
				StartCoroutine(ScaleDownOverTime(player2Hand[i], .1f));
			}
        }

        player1card = null;
        player2card = null;

        player1selected = false;
        player2selected = false;

		MovesRemaining.movesLeft = 5;
    }

    public void ChangeBackground()
    {
        int butt = (int)Random.Range(1, 4);

        // randomize playfield
        if (butt == 1)
        {
            Background.currentType = BackgroundType.Fire;
            QuadBackground.currentType = BackgroundType.Fire;
        }
        else if (butt == 2)
        {
            Background.currentType = BackgroundType.Grass;
            QuadBackground.currentType = BackgroundType.Grass;
        }
        else if (butt == 3)
        {
            Background.currentType = BackgroundType.Water;
            QuadBackground.currentType = BackgroundType.Water;
        }
    }
    public void ResetHands()
    {
        foreach (Card card in player1Hand)
        {
            card.selected = false;
            card.attacked = false;
        }

        foreach (Card card in player2Hand)
        {
            card.selected = false;
            card.attacked = false;
        }
        
        
              
        
        
        
        //for (int i = 0; i < 5; i++)
        //{
        //    player1Hand[i].selected = false;
        //    player1Hand[i].attacked = false;
        //    player1Hand[i].dead = false;
        //    player2Hand[i].selected = false;
        //    player2Hand[i].attacked = false;
        //    player2Hand[i].dead = false;
        //}
    }
    IEnumerator ChangePosition(Card temp, float time, Vector3 destination)
    {
        // set the current size and target size
        Vector3 originalPosition = temp.transform.position;

        // zero the time
        float currentTime = 0.0f;

        do
        {
            // scale up and increase time each frame
            temp.transform.position = Vector3.Lerp(originalPosition, destination, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }

    public void FightSound(PlayerTurn player)
    {
        if (whichTurn == player)
        {
            SoundManager.instance.PlaySound("goodAttack", 1f);
        }
        else
        {
            SoundManager.instance.PlaySound("badAttack", 1f);
        }
    }
}
