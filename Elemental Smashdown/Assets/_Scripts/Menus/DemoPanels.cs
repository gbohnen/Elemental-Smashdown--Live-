using UnityEngine;
using System.Collections;

public class DemoPanels : MonoBehaviour {

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject tiePanel;
    public GameObject demoPanel;
    public GameObject UIpanel;

    public void UpdatePanels()
    {
        ResetPanels();

        switch (TutorialButtons.currentPage)
        {
            case 5:
                winPanel.GetComponent<CanvasGroup>().alpha = 1;
                break;
            case 6:
                losePanel.GetComponent<CanvasGroup>().alpha = 1;
                break;
            case 7:
                tiePanel.GetComponent<CanvasGroup>().alpha = 1;
                break;
            case 9:
                demoPanel.GetComponent<CanvasGroup>().alpha = 1;
                demoPanel.GetComponent<CanvasGroup>().interactable = true;
                demoPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
                break;
            case 11:
                UIpanel.GetComponent<CanvasGroup>().alpha = 1;
                UIpanel.GetComponent<CanvasGroup>().interactable = true;
                UIpanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
                break;
            default:
                break;
        }
            
    }

    public void ResetPanels()
    {
        winPanel.GetComponent<CanvasGroup>().alpha = 0;
        losePanel.GetComponent<CanvasGroup>().alpha = 0;
        tiePanel.GetComponent<CanvasGroup>().alpha = 0;
        demoPanel.GetComponent<CanvasGroup>().alpha = 0;
        demoPanel.GetComponent<CanvasGroup>().interactable = false;
        demoPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        UIpanel.GetComponent<CanvasGroup>().alpha = 0;
        UIpanel.GetComponent<CanvasGroup>().interactable = false;
        UIpanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}