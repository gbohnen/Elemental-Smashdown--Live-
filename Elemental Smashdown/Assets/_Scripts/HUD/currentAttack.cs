using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class currentAttack : MonoBehaviour {

	public bool active = true;


	// Update is called once per frame
	void Update () {

		if (active) {
			if (Background.currentType == BackgroundType.Fire) 
			{
				Text text = GetComponent<Text>();
				text.text = "Fire";
			} 
			else if (Background.currentType == BackgroundType.Grass) 
			{
				Text text = GetComponent<Text>();
				text.text = "Grass";
			} 
			else 
			{
				Text text = GetComponent<Text>();
				text.text = "Water";
			}
		} 
		else 
		{
			Text text = GetComponent<Text>();
			text.text = "";
		}
		
		if (Input.GetKeyDown (KeyCode.I)) 
		{
			active = !active;
		}
	}
}
