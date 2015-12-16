using UnityEngine;
using System.Collections;

public class SaveAndLoad : MonoBehaviour
{
    public GameObject pauseMenu;

    public void ClickSave()
    {
        LevelSerializer.Checkpoint();
        pauseMenu.GetComponent<PauseMenu24>().Resume();
        NotificationList.instance.AddItem("Game saved...");
    }

    public void ClickLoad()
    {
        LevelSerializer.Resume();
        pauseMenu.GetComponent<PauseMenu24>().Resume();
        NotificationList.instance.AddItem("Loaded last checkpoint...");
    }
}
