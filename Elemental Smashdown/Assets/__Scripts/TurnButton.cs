using UnityEngine;
using System.Collections;

public class TurnButton : MonoBehaviour {

    public GameObject light;

	public bool active = true;

	public Sprite sprite;

	// Use this for initialization
	void Start () {
        OnMouseDown();
		sprite = GetComponent<SpriteRenderer> ().sprite;
	}

    void Awake()
    {
        light = GameObject.Find("PlayerLight");
    }
	
	// Update is called once per frame
	void Update () {
		if (active)
		{
			SpriteRenderer spriteRend = this.GetComponent<SpriteRenderer>();
			spriteRend.sprite = this.sprite;
		}
		else
		{
			SpriteRenderer spriteRend = this.GetComponent<SpriteRenderer>();
			spriteRend.sprite = null;
		}
		
		if (Input.GetKeyDown(KeyCode.I))
		{
			active = !active;
		}
	}

    public void OnMouseDown()
    {
        StartCoroutine(BounceButton(this.gameObject, .1f));

        // switch players
        if (PlayerController.whichTurn == PlayerTurn.Player1)
        {
            Vector3 pos = light.transform.position;
            pos.y = -10;
            light.transform.position = pos;

            pos = GameObject.FindGameObjectWithTag("Indic").GetComponent<SpriteRenderer>().transform.position;
            pos.y = -5;
            GameObject.FindGameObjectWithTag("Indic").GetComponent<SpriteRenderer>().transform.position = pos;

            PlayerController.whichTurn = PlayerTurn.Player2;
        }
        else
        {
            Vector3 pos = light.transform.position;
            pos.y = 10;
            light.transform.position = pos;

            pos = GameObject.FindGameObjectWithTag("Indic").GetComponent<SpriteRenderer>().transform.position;
            pos.y = 5;
            GameObject.FindGameObjectWithTag("Indic").GetComponent<SpriteRenderer>().transform.position = pos;

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
    }

    IEnumerator BounceButton(GameObject temp, float time)
    {
        // set the current size and target size
        Vector3 originalScale = temp.transform.localScale;
        Vector3 destinationScale = temp.transform.localScale -= new Vector3(0.40f, 0.40f, 0f);

        // zero the time
        float currentTime = 0.0f;

        do
        {
            // scale up and increase time each frame
            temp.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        // set the current size and target size
        originalScale = temp.transform.localScale;
        destinationScale = temp.transform.localScale += new Vector3(0.40f, 0.40f, 0f);

        // zero the time
        currentTime = 0.0f;

        do
        {
            // scale up and increase time each frame
            temp.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }
}
