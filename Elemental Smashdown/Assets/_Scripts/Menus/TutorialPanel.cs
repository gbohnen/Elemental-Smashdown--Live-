using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialPanel : MonoBehaviour {

	public GameObject textBox;
	public static bool isComplete = false;

	void Update()
	{
		if (TutorialButtons.pageCount == TutorialButtons.currentPage)
			GetComponent<CanvasGroup> ().alpha = 1;
		else
			GetComponent<CanvasGroup> ().alpha = 0;
	}

	public void ClickSalamander()
	{
		textBox.GetComponent<Text> ().text = "Fire Salamander's attack in the current element (Fire) is higher than Grandpa Tim's. Tim will die if he attacks the salamander. Try another attack.";
	}

	public void ClickElemental()
	{
		textBox.GetComponent<Text> ().text = "This elemental has the same attack as Tim. They will both die from this battle. Sometimes this can be advantagous, but let's see if there's a better option.";
	}

	public void ClickCaterpillar()
	{
		textBox.GetComponent<Text> ().text = "Tim can handily defeat this caterpillar, at least in fire. Looks like you're ready to play! Click play to begin the game when both players are ready.";
		isComplete = true;
	}
}
