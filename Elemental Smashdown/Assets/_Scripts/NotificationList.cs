using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class NotificationList : MonoBehaviour {

    public static NotificationList instance = null;

    public GameObject sampleText;
    public List<Text> textList;

    public Transform contentPanel;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(string text)
    {
        GameObject newButton = Instantiate(sampleText) as GameObject;
        Text temp = newButton.GetComponent<Text>();
        temp.text = text;
		temp.fontSize = (int)(Screen.width / 73);
		temp.GetComponent<LayoutElement> ().minHeight = temp.fontSize + 4;

        newButton.transform.SetParent(contentPanel);
    }
}
