using UnityEngine;
using System.Collections;

public class DemoPanels : MonoBehaviour {

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject tiePanel;
    public GameObject demoPanel;

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
    }
}