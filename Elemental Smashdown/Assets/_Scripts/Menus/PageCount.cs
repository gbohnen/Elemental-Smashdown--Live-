using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PageCount : MonoBehaviour {

	public void Update()
	{
		Text text = GetComponent<Text> ();
		text.text = (TutorialButtons.currentPage).ToString () + " / " + TutorialButtons.pageCount.ToString ();
	}

}
