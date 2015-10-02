using UnityEngine;
using System.Collections;

public class Indicator : MonoBehaviour {
    public static BackgroundType currentType = BackgroundType.Water;

    public Sprite fire;
    public Sprite grass;
    public Sprite water;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (currentType == BackgroundType.Fire)
        {
            SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
            sprite.sprite = fire;
        }
        else if (currentType == BackgroundType.Grass)
        {
            SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
            sprite.sprite = grass;
        }
        else
        {
            SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
            sprite.sprite = water;
        }

    }
}
