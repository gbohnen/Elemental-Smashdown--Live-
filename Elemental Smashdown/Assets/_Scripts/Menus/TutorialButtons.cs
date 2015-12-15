using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialButtons : MonoBehaviour {

	public static bool isComplete = false;
	public static int pageCount = 10;
	public static int currentPage = 1;

	public void Awake()
	{
		currentPage = 1;
	}

	public void Update()
	{
		Button temp = GetComponent<Button> ();

		switch (name) 
		{
			case "Play":
				temp.interactable = isComplete;
				break;
			case "Main Menu":
				break;
			case "Prev":
				if (currentPage <= 1)
					temp.interactable = false;
				else
					temp.interactable = true;
				break;
			case "Next":
				if (currentPage >= pageCount)
					temp.interactable = false;
				else
					temp.interactable = true;
				break;
			default:
				break;
		}
	}

	public void OnClickPrev()
	{
		if (currentPage > 1)
			currentPage--;
	}

	public void OnClickNext()
	{
		if (currentPage < pageCount) 
			currentPage++;

		if (currentPage == pageCount) 
			isComplete = true;
	}

	public void OnClickMainMenu()
	{
		Application.LoadLevel ("Main menu");
	}

	public void OnClickPlay()
	{
		Application.LoadLevel ("play");
	}
}
