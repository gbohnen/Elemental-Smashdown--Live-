using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour {
	
	void Update () {
		Text text = GetComponent<Text> ();
		text.text = "Tutorial Page: #" + TutorialButtons.currentPage.ToString();
	}
}
