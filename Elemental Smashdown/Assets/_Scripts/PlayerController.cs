using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PlayerTurn
{
    Player1,
    Player2
}

public class PlayerController : MonoBehaviour
{

    public static PlayerTurn whichTurn = PlayerTurn.Player1;
    public static PlayerController instance = null;
    public Card player1card;
    public Card player2card;
    public bool player1selected = false;
    public bool player2selected = false;
    public Card[] player1Hand;
    public Card[] player2Hand;

    public bool hasResed;
    public bool player1space;
    public bool player2space;

    public Transform cardReferenceTransform;

    // helpful hints controllers
    int tiesTally = 0;
    int badAttackTally = 0;
    float timeSinceAction = 0;

    // Use this for initialization
    void Start()
    {
        instance = this;

        hasResed = false;
        player1space = false;
        player2space = false;

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

        Player1Score.player1score = 0;
        Player2Score.player2score = 0;

        NotificationList.instance.AddItem("Press Esc at any time to view the Help Menu.");

		// pick a random player to start
		int random = (int)Random.Range (0, 2);
		GameObject button = GameObject.FindGameObjectWithTag ("TurnButton");
		switch (random) {
		case 0:
			whichTurn = PlayerTurn.Player2;
			button.GetComponent<TurnButton>().OnMouseDown();
			break;
		case 1:
			whichTurn = PlayerTurn.Player1;
			button.GetComponent<TurnButton>().OnMouseDown();
			break;
		default:
			break;
		}
    }

    // Update is called once per frame
    void Update()
    {
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

        timeSinceAction += Time.deltaTime;

        if (timeSinceAction > 30)
        {
            NotificationList.instance.AddItem("Press Esc at any time to view the Help Menu.");
            timeSinceAction = 0;
        }
    }

    void Draw()
    {
        player1Hand[0].transform.position = new Vector3(-5, 5, 0);
        player1Hand[1].transform.position = new Vector3(-1, 5, 0);
        player1Hand[2].transform.position = new Vector3(3, 5, 0);
        player1Hand[3].transform.position = new Vector3(7, 5, 0);
        player1Hand[4].transform.position = new Vector3(11, 5, 0);

        player2Hand[0].transform.position = new Vector3(-5, -5, 0);
        player2Hand[1].transform.position = new Vector3(-1, -5, 0);
        player2Hand[2].transform.position = new Vector3(3, -5, 0);
        player2Hand[3].transform.position = new Vector3(7, -5, 0);
        player2Hand[4].transform.position = new Vector3(11, -5, 0);
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
        timeSinceAction = 0;

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


    }

    IEnumerator ScaleUpOverTime(Card temp, float time)
    {
        // set the current size and target size
        Vector3 originalScale = cardReferenceTransform.localScale;
        Vector3 destinationScale = new Vector3(1.638793f, 1.638793f, 1);

        // zero the time
        float currentTime = 0.0f;

        do
        {
            // scale up and increase time each frame
            temp.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
        temp.transform.localScale = destinationScale;

        CheckBothSelected();
    }

    IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }


    IEnumerator ScaleDownOverTime(Card temp, float time)
    {
        // set the current size and target size
        Vector3 originalScale = new Vector3(1.638793f, 1.638793f, 1);
        Vector3 destinationScale = cardReferenceTransform.localScale;

        // zero the time
        float currentTime = 0.0f;

        do
        {
            // scale up and increase time each frame
            temp.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        temp.transform.localScale = destinationScale;
    }

    IEnumerator FlipCard(Card temp, float time)
    {
        // set the current size and target size
        Vector3 originalScale = cardReferenceTransform.localScale;
        Vector3 destinationScale = new Vector3(0, cardReferenceTransform.localScale.y, 1);

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

        temp.transform.localScale = originalScale;
    }

    IEnumerator MoveTo(Card temp, Vector3 target, float time)
    {
        // set the current size and target size
        Vector3 originalPos = temp.transform.position;

        // zero the time
        float currentTime = 0.0f;

        do
        {
            // scale up and increase time each frame
            temp.transform.position = Vector3.Lerp(originalPos, target, currentTime / time);
            currentTime += Time.deltaTime;
            yield return new WaitForSeconds(1);
        } while (currentTime <= time);

        temp.transform.position = target;
    }

    void Player1Win(Card player1, Card player2)
    {
        player2card.dead = true;
        player2space = true;
        NotificationList.instance.AddItem("Player 1's " + player1card.cardName.ToString() + " wins!");
        ResurrectionList.instance.AddCard(player2card);
        FightSound(PlayerTurn.Player1);
        tiesTally = 0;
        if (whichTurn == PlayerTurn.Player2)
        {
            badAttackTally++;
            if (badAttackTally >= 3)
            {
                NotificationList.instance.AddItem("Consider your attacks carefully before choosing.");
                badAttackTally = 0;
            }
        }
    }

    void Player2Win(Card player1, Card player2)
    {
        player1card.dead = true;
        player1space = true;
		NotificationList.instance.AddItem("Player 2's " + player2card.cardName.ToString() + " wins!");
        ResurrectionList.instance.AddCard(player1card);
        FightSound(PlayerTurn.Player2);
        tiesTally = 0;
        if (whichTurn == PlayerTurn.Player1)
        {
            badAttackTally++;
            if (badAttackTally >= 3)
            {
                NotificationList.instance.AddItem("Consider your attacks carefully...");
                badAttackTally = 0;
            }
        }
    }

    void Tie(Card player1, Card player2)
    {
        player2card.dead = true;
        player1card.dead = true;
        player1space = true;
        player2space = true;
        NotificationList.instance.AddItem("It's a tie...");
        ResurrectionList.instance.AddCard(player1card);
        ResurrectionList.instance.AddCard(player2card);
        tiesTally++;
        if (tiesTally >= 3)
        {
            NotificationList.instance.AddItem("Try to minimize your ties so you don't");
            NotificationList.instance.AddItem("help your enemy!");
        }
    }

    public void Fight(Card player1, Card player2)
    {
        // fight in fire
        if (Background.currentType == BackgroundType.Fire)
        {
            if (player1card.stats.x > player2card.stats.x)
            {
                Player1Win(player1, player2);
                Player1Score.player1score += (int)(player1card.stats.x - player2card.stats.x);
            }
            else if (player1card.stats.x < player2card.stats.x)
            {
                Player2Win(player1, player2);
                Player2Score.player2score += (int)(player2card.stats.x - player1card.stats.x);
            }
            else if (player1card.stats.x == player2card.stats.x)
            {
                Tie(player1, player2);
            }
        }
        // fight in grass
        else if (Background.currentType == BackgroundType.Water)
        {
            if (player1card.stats.y > player2card.stats.y)
            {
                Player1Win(player1, player2);
                Player1Score.player1score += (int)(player1card.stats.y - player2card.stats.y);
            }
            else if (player1card.stats.y < player2card.stats.y)
            {
                Player2Win(player1, player2);
                Player2Score.player2score += (int)(player2card.stats.y - player1card.stats.y);
            }
            else if (player1card.stats.y == player2card.stats.y)
            {
                Tie(player1, player2);
            }
        }
        // fight in water
        else if (Background.currentType == BackgroundType.Grass)
        {
            if (player1card.stats.z > player2card.stats.z)
            {
                Player1Win(player1, player2);
                Player1Score.player1score += (int)(player1card.stats.z - player2card.stats.z);
            }
            else if (player1card.stats.z < player2card.stats.z)
            {
                Player2Win(player1, player2);
                Player2Score.player2score += (int)(player2card.stats.z - player1card.stats.z);
            }
            else if (player1card.stats.z == player2card.stats.z)
            {
                Tie(player1, player2);
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
                StartCoroutine(ChangePosition(player1Hand[i], .5f, new Vector3(4 * i - 5, 5, 0)));
                StartCoroutine(FlipCard(player1Hand[i], .5f));
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
                StartCoroutine(ChangePosition(player2Hand[i], .5f, new Vector3(4 * i - 5, -5, 0)));
                StartCoroutine(FlipCard(player2Hand[i], .5f));
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

        timeSinceAction = 0;

        hasResed = false;
        player2space = false;
        player1space = false;
    }

    public void ChangeBackground()
    {
        int butt = (int)Random.Range(1, 4);

        GameObject wheel = GameObject.FindGameObjectWithTag("Wheel");
		GameObject turnWheel = GameObject.FindGameObjectWithTag ("TurnWheel");

        // randomize playfield
        if (butt == 1)
        {
            Background.currentType = BackgroundType.Fire;
            QuadBackground.currentType = BackgroundType.Fire;
            StartCoroutine(ChangeRotation(wheel, new Vector3(0, 0, 120), .8f));
        }
        else if (butt == 2)
        {
            Background.currentType = BackgroundType.Grass;
            QuadBackground.currentType = BackgroundType.Grass;
            StartCoroutine(ChangeRotation(wheel, new Vector3(0, 0, -120), .8f));
        }
        else if (butt == 3)
        {
            Background.currentType = BackgroundType.Water;
            QuadBackground.currentType = BackgroundType.Water;
            StartCoroutine(ChangeRotation(wheel, new Vector3(0, 0, 0), .8f));
        }

		// spin the player wheel
		if (whichTurn == PlayerTurn.Player1)
			StartCoroutine(ChangeRotation (turnWheel, new Vector3(0, 0, 90), .8f));
		else
			StartCoroutine(ChangeRotation (turnWheel, new Vector3(0, 0, 270), .8f));
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

        temp.transform.position = destination;
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

    IEnumerator ChangeRotation(GameObject temp, Vector3 target, float time)
    {
        // set the current size and target size
        Vector3 originalRotation = temp.transform.eulerAngles;

        // zero the time
        float currentTime = 0.0f;

        do
        {
            // scale up and increase time each frame
            temp.transform.eulerAngles = Vector3.Lerp(originalRotation, target, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        temp.transform.eulerAngles = target;
    }

    public void CheckBothSelected()
    {
        // call the fight method
        if (player1selected && player2selected)
        {
            Fight(player1card, player2card);

            // set cards as attacked
            player1card.attacked = true;
            player2card.attacked = true;

            // reset cards
            StartCoroutine(ScaleDownOverTime(player1card, .2f));
            player2card.transform.localScale = cardReferenceTransform.localScale;
            player1card.selected = false;
            player2card.selected = false;
            player1selected = false;
            player2selected = false;
            player1card = null;
            player2card = null;
        }

    }

    public void Resurrect(Card temp)
    {
        if (whichTurn == PlayerTurn.Player1)
        {

        }
        else
        {

        }

    }
}