using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuTips : MonoBehaviour {

	public void GetNewTip()
	{
		Text text = GetComponentInChildren<Text> ();
		int num = Random.Range (0, 3);

		switch (num) 
		{
		case 0:
			text.text = "Press Esc to access the pause menu in game.";
			break;
		case 1:
			text.text = "Remember to check the active battle type. Reading the correct numbers is ultimately the most important.";
			break;
		case 2:
			text.text = "Try to minimize ties. Remember, the enemy gets points for them too.";
			break;
		default:
			text.text = "Click to get a random tip!";
			break;
		}
	}

}
