using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movesText : MonoBehaviour {

	public bool active = true;

	public string phrase;
	
	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		Text gt = this.GetComponent<Text> ();
		
		if (active)
		{		
			gt.text = phrase;
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
