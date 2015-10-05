using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player1Score : MonoBehaviour {

    public static int player1score = 0;

	public bool active = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Text gt = this.GetComponent<Text> ();

		if (active)
		{
			gt.text = "Player 1 Score: " + player1score.ToString ();
		} 
		else 
		{
			gt.text = null;
		}

		if (Input.GetKeyDown (KeyCode.I)) 
		{
			active = !active;
		}
	}
}
