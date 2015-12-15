using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

[System.Serializable]
public class ResurrectionButton {
    public string characterName;
    public string fireStat;
    public string waterStat;
    public string grassStat;
    public Sprite cardSprite;
}

public class ResurrectionList : MonoBehaviour {

    public static ResurrectionList instance;

    public GameObject buttonPrefab;
    public List<ResurrectionButton> resurrectionList;
    public Transform contentPanel;

	// Use this for initialization
    void Start()
    {
        instance = this;
    }

    public void AddCard(Card temp)
    {
        ResurrectionButton button = new ResurrectionButton();
        button.characterName = temp.cardName;
        button.fireStat = temp.stats.x.ToString();
        button.waterStat = temp.stats.y.ToString();
        button.grassStat = temp.stats.z.ToString();
        button.cardSprite = temp.sprite;

        GameObject newButton = Instantiate(buttonPrefab) as GameObject;
        SampleButton resurrectionButton = newButton.GetComponent<SampleButton>();
        resurrectionButton.characterName.text = button.characterName;
        resurrectionButton.fireStat.text = button.fireStat;
        resurrectionButton.waterStat.text = button.waterStat;
        resurrectionButton.grassStat.text = button.grassStat;
        resurrectionButton.cardSprite = button.cardSprite;
        newButton.transform.SetParent(contentPanel);
    }
}
