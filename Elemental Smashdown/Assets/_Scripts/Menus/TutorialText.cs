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
			text.text = "Welcome to Elemental Smashdown, the exciting monster fighting game!";
			break;
		case 2:
			text.text = "Every turn, a random element will be chosen, and monsters will use attacks of that element.";
			break;
		case 3:
            text.text = "It's up to you to plan your turns and kill your opponent's monsters. \n\nPlay it smart, and you can get 20 points for the win!";
			break;
		case 4:
			text.text = "Click on your own monster to select it, then click on the opponent that you want to attack.";
			break;
		case 5:
            // demo panel: your card is better than theirs
			text.text = "";
			break;
		case 6:
            // demo panel: their card is better than yours
			text.text = "";
			break;
        case 7:
            // demo panel: both cards tie
            text.text = "";
            break;
        case 8:
            text.text = "Let's try it out! \n\nWhich of the following is the best attack?";
            break;
        case 9:
            // demo panel: pick the best choice
            text.text = "";
            break;
        case 10:
            text.text = "Nice work! Let's check out some parts of the interface.";
            break;
        case 11:
            // demo panel: show off the interface elements
            text.text = "";
            break;
        case 12:
            text.text = "Looks like you're ready to go! Let's go try it out for real.";
            break;
        default:
			break;
		}
	}
}
