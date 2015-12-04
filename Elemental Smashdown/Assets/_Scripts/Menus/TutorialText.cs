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
			text.text = "Click your own monster to select it.\n\nClick your enemy's monster to make the two fight!";
			break;
		case 2:
			text.text = "Whichever has the highest elemental stat wins.\n\nThe surviving monster will turn grey, which means it cannot attack again this turn.";
			break;
		case 3: 
			text.text = "You get a point if you kill the enemy monster, and the first person to get to 20 wins!";
			break;
		case 4:
			text.text = "Let's try a quick demonstration.";
			break;
		case 5:
			text.text = "Which of the following attacks is the best choice?";
			break;
		case 6:
			text.text = "";
			break;
		default:
			break;
		}
	}
}
