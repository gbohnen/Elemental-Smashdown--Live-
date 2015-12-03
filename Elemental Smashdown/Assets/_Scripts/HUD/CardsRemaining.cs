using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardsRemaining : MonoBehaviour {

	public bool active = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {      

		Text gt = this.GetComponent<Text> ();
		
		if (active)
		{
			gt.text = "Cards Left: " + Deck.cardsRemaining.ToString();
		} 
		else 
		{
			gt.text = null;
		}
		
		if (Input.GetKeyDown (KeyCode.I)) 
		{
			active = !active;
		}
    }
}
