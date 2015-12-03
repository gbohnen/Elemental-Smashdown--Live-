using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Card : MonoBehaviour {

    public Vector3 stats;
    public Sprite sprite;
    public string cardName;
    public Sprite back;
    public bool flipped = true;
    public bool dead = false;
    public PlayerTurn belongsTo;
    public bool selected = false;
    public bool attacked = false;

    public Card(Card copy)
    {
        this.stats = copy.stats;
        this.sprite = copy.sprite;
		this.cardName = copy.cardName;
        this.back = copy.back;
        this.flipped = copy.flipped;
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

		SpriteRenderer temp = GetComponent<SpriteRenderer>();

		if (this.attacked)
		{
			temp.color = new Color(.3f, .3f, .3f, 1);
		} 
		else 
		{
			temp.color = new Color(1, 1, 1, 1);
		}

        if (!this.flipped && !dead)
        {
            this.GetComponent<SpriteRenderer>().sprite = this.sprite;
        }
        else if (this.flipped && !dead)
        {
            this.GetComponent<SpriteRenderer>().sprite = this.back;
        }
        else if (dead)
        {
            this.GetComponent<SpriteRenderer>().sprite = null;
        }
	}

    public void OnMouseDown()
    {
        if (attacked == false)
        {
            PlayerController temp = GameObject.FindGameObjectWithTag("controller").GetComponent<PlayerController>();

            temp.SelectCard(this);
        }
    }
}