using UnityEngine;
using System.Collections;

public class Menus : MonoBehaviour
{
	public bool loadTutorial = true;
	
	public void MainMenu()
	{
		SoundManager.instance.PlaySound("click", 1f);
		Application.LoadLevel("Main menu");
	}
	public void PlayAgain()
	{
		SoundManager.instance.PlaySound("click", 1f);
		Application.LoadLevel("play");
	}
    public void StartButtonPressed()
    {
        SoundManager.instance.PlaySound("click", 1f);
		if (loadTutorial)
			Application.LoadLevel ("tutorial");
		else
			Application.LoadLevel ("play");
    }
    public void QuitButtonPressed()
    {
        SoundManager.instance.PlaySound("click", 1f);
        Application.Quit();
    }
    public void HelpButtonPressed()
    {
        SoundManager.instance.PlaySound("click", 1f);
        Application.LoadLevel("help");
    }
	public void QuestButtonPressed()
	{
		SoundManager.instance.PlaySound("click", 1f);
		Application.LoadLevel ("QuestRoom");
	}
    public void BackButtonPressed()
    {
        SoundManager.instance.PlaySound("click", 1f);
        Application.LoadLevel("Main menu");
    }
	public void TogglePress()
	{
		loadTutorial = !loadTutorial;
	}
}
