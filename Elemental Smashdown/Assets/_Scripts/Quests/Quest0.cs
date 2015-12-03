using UnityEngine;
using System.Collections;

public class Quest0 : QuestCard
{

    string text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<TextMesh>().text;
    }

    // Update is called once per frame
    void Update()
    {
        TextMesh mesh = GetComponent<TextMesh>();

        if (base.isFlipped)
        {
            mesh.text = " ";
        }
        else
        {
            mesh.text = text;
        }
    }
}