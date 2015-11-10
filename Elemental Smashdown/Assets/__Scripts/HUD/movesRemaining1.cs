using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movesRemaining1 : MonoBehaviour {
	
	public bool active = true;

	public Sprite sprite;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (active)
		{
			Image image = GetComponent<Image>();
			image.color = new Color(1, 1, 1, 1);
		} 
		else 
		{
			Image image = GetComponent<Image>();
			image.color = new Color(0, 0 ,0 ,0);
		}
		
		if (Input.GetKeyDown (KeyCode.I)) 
		{
			active = !active;
		}
	}
}
