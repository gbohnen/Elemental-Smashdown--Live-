using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour {
	
	void Update () {
		Text text = GetComponent<Text> ();
		text.text = "Tutorial Page: #" + TutorialButtons.currentPage.ToString();

		switch (TutorialButtons.currentPage)
		{
		case 1:
			text.text = "Click your own monster to select it.";
			break;
		case 2:
			text.text = "Click your enemy's monster to make the two fight!";
			break;
		case 3: 
			text.text = "Whichever has the highest elemental stat wins.";
			break;
		case 4:
			text.text = "You get a point if you kill the enemy monster";
			break;
		case 5:
			text.text = "The first person to get 20 points wins!";
			break;
		case 6:
			text.text = "Remeber to have fun!";
			break;
		case 7:
			text.text = "Note: Multiple selection is disabled because of a number of bugs.";
			break;
		case 8:
			text.text = "Single selection works as long as you do it first.";
			break;
		case 9:
			text.text = "Use the toggle on the next screen to try both modes out.";
			break;
		default:
			break;
		}
	}
}
