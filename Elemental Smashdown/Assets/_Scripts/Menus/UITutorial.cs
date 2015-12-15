using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITutorial : MonoBehaviour {

	public GameObject textBox;

	public void ClickScoreBar()
	{
		textBox.GetComponent<Text> ().text = "This will show you your score. It will fill up as you earn points. Both players have one at the top and bottom of the screen.";
	}

	public void ClickElementWheel()
	{
		textBox.GetComponent<Text> ().text = "This wheel will show you what kind of attack you should use each turn. Pay attention, because it changes every turn!";
	}

	public void ClickEndTurn()
	{
		textBox.GetComponent<Text> ().text = "This dial will show whose turn it is. Click it after you've made all your attacks in a turn.";
	}

    public void ClickConsole()
    {
        textBox.GetComponent<Text>().text = "This console will show you tips and information throughout the game. Keep an eye on it!";
    }

    public void ClickResurrection()
    {
        textBox.GetComponent<Text>().text = "Once per turn, you can bring a monster that died back to fight for you, as long as you have space in your hand! Click an item from the list to resurrect a monster.";
    }
}
