using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player2Score : MonoBehaviour {

	public static int player2score = 0;
	
	public bool active = true;
	
	Image image;
    Text text;
	
	// Use this for initialization
	void Awake () {
		image = GetComponent<Image> ();
        text = GameObject.FindGameObjectWithTag("Player2Score").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (active)
		{
			image.fillAmount = player2score * .05f;
            text.text = "Player 2 Score: " + player2score.ToString() + "/20";
		} 
		else 
		{
			image.fillAmount = 0;
		}
		
		if (Input.GetKeyDown (KeyCode.I)) 
		{
			active = !active;
		}
	}
}