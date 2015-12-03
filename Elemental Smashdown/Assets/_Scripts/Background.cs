using UnityEngine;
using System.Collections;

public enum BackgroundType
{
	Fire,
	Water,
	Grass
}

public class Background : MonoBehaviour {
        
    public static BackgroundType currentType = BackgroundType.Water;

    public Sprite fire;
    public Sprite grass;
    public Sprite water;

	public bool active = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			if (currentType == BackgroundType.Fire) 
			{
				SpriteRenderer sprite = this.GetComponent<SpriteRenderer> ();
				sprite.sprite = fire;
			} 
			else if (currentType == BackgroundType.Grass) 
			{
				SpriteRenderer sprite = this.GetComponent<SpriteRenderer> ();
				sprite.sprite = grass;
			} 
			else 
			{
				SpriteRenderer sprite = this.GetComponent<SpriteRenderer> ();
				sprite.sprite = water;
			}
		} 
		else 
		{
			SpriteRenderer sprite = this.GetComponent<SpriteRenderer> ();
			sprite.sprite = null;
		}

		if (Input.GetKeyDown (KeyCode.I)) 
		{
			active = !active;
		}
	}
}
