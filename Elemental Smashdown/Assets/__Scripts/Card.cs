using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card : MonoBehaviour {

    public Vector3 stats;
    public Sprite sprite;
    public string name;
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
        this.name = copy.name;
        this.back = copy.back;
        this.flipped = copy.flipped;
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
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