using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovesRemaining : MonoBehaviour {
	
	public static int movesLeft = 5;
	
	public bool active = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (active)
		{
			Image image = GetComponent<Image>();
			image.fillAmount = movesLeft * .2f;
		} 
		else 
		{
			Image image = GetComponent<Image>();
			image.fillAmount = 0;
		}
		
		if (Input.GetKeyDown (KeyCode.I)) 
		{
			active = !active;
		}
	}
}
