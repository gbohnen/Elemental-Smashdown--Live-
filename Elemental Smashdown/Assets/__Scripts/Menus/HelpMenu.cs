using UnityEngine;
using System.Collections;

public class HelpMenu : MonoBehaviour {

	public bool active = false;
	public Sprite sprite;
	
	// Update is called once per frame
	void Update () {

		if (active)
		{
			SpriteRenderer spriteRend = this.GetComponent<SpriteRenderer>();
			spriteRend.sprite = this.sprite;
		}
		else
		{
			SpriteRenderer spriteRend = this.GetComponent<SpriteRenderer>();
			spriteRend.sprite = null;
		}

		if (Input.GetKeyDown(KeyCode.I))
		    {
			active = !active;
		}
}
}