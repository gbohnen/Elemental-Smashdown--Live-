﻿using UnityEngine;
using System.Collections;

public class PauseMenu24 : MonoBehaviour {

	public bool isPaused = false;

	void Start()
	{
		gameObject.GetComponent<CanvasGroup>().interactable = false;
		gameObject.GetComponent<CanvasGroup>().alpha = 0f;
		gameObject.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		isPaused = false;

		Time.timeScale = 1;
	}


	void Update()
	{		
		if (Input.GetKeyDown (KeyCode.Escape) && !isPaused) {
			gameObject.GetComponent<CanvasGroup>().interactable = true;
			gameObject.GetComponent<CanvasGroup>().alpha = 1f;
			gameObject.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			isPaused = true;
			Time.timeScale = 0;
		} 
		else if (Input.GetKeyDown (KeyCode.Escape) && isPaused) 
		{
			gameObject.GetComponent<CanvasGroup>().interactable = false;
			gameObject.GetComponent<CanvasGroup>().alpha = 0f;
			gameObject.GetComponent<CanvasGroup> ().blocksRaycasts = false;
			isPaused = false;
			Time.timeScale = 1;
		}
	}

	public void ResetGame()
	{
		SoundManager.instance.PlaySound("click", 1f);
		Application.LoadLevel ("play");
	}

	public void MainMenu()
	{
		SoundManager.instance.PlaySound("click", 1f);
		Application.LoadLevel ("Main menu");
	}

	public void Quit()
	{
		SoundManager.instance.PlaySound("click", 1f);
		Application.Quit ();
	}

	public void Resume()
	{
		SoundManager.instance.PlaySound("click", 1f);
		gameObject.GetComponent<CanvasGroup>().interactable = false;
		gameObject.GetComponent<CanvasGroup>().alpha = 0f;
		gameObject.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		isPaused = false;
		Time.timeScale = 1;
	}
}
