using UnityEngine;
using System.Collections;

public class TurnButton : MonoBehaviour {

    public GameObject playerLight;
    public GameObject indicator;

	public bool active = true;

	public Sprite sprite;

    Vector3 lightpos1 = new Vector3(3, 10, -7);
    Vector3 lightpos2 = new Vector3(3, -10, -7);
    Vector3 quadpos1 = new Vector3(3, 5, 0);
    Vector3 quadpos2 = new Vector3(3, -5, 0);

	// Use this for initialization
	void Start () {

    }

    void Awake()
    {
		playerLight = GameObject.Find("PlayerLight");
        indicator = GameObject.Find("PlayerIndicator");
    }
	
	// Update is called once per frame
	void Update () {
		if (active)
		{
		}
		else
		{
		}
		
		if (Input.GetKeyDown(KeyCode.I))
		{
			active = !active;
		}
	}

    public void OnMouseDown()
    {

        // switch players
        if (PlayerController.whichTurn == PlayerTurn.Player1)
        {

			StartCoroutine(ChangePosition(playerLight, .3f, lightpos2));
            StartCoroutine(ChangePosition(indicator, .3f, quadpos2));

            PlayerController.whichTurn = PlayerTurn.Player2;
        }
        else
        {
			StartCoroutine(ChangePosition(playerLight, .3f, lightpos1));
            StartCoroutine(ChangePosition(indicator, .3f, quadpos1));

            PlayerController.whichTurn = PlayerTurn.Player1;
        }

        // clear dead cards
        // call the reset board
        PlayerController temp = GameObject.FindGameObjectWithTag("controller").GetComponent<PlayerController>();

        
        temp.ResetBoard();
        temp.ChangeBackground();
        temp.ResetHands();

        // play end of turn sound
        SoundManager.instance.PlaySound("endTurn", 1f);

        CallPlayer();
    }

    IEnumerator ChangePosition(GameObject temp, float time, Vector3 destination)
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

    static void CallPlayer()
    {
        string text;
        if (QuadBackground.currentType == BackgroundType.Fire)
            text = "Kill them with FIRE!";
        else if (QuadBackground.currentType == BackgroundType.Grass)
            text = "Use your GRASS powers to fight!";
        else
            text = "WATER you doing? Go fight!";
        NotificationList.instance.AddItem(PlayerController.whichTurn.ToString() + " is up. " + text);
    }
}
