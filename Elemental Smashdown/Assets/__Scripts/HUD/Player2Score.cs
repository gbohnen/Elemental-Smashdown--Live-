using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player2Score : MonoBehaviour {

	public static int player2score = 0;
	
	public bool active = true;
	
	Image image;
	
	// Use this for initialization
	void Awake () {
		image = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (active)
		{
			image.fillAmount = player2score * .05f;
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
