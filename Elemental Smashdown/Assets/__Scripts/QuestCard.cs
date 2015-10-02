using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestCard : MonoBehaviour {

	public bool isActive = false;
	public bool isCompleted = false;
	public bool isFlipped;

	public Sprite front;
	public Sprite back;
	public Sprite complete;

	Vector3 startSize;
	Vector3 targetSize;

	float time = .5f;

	void Start(){
		startSize = new Vector3 (1, 1, 1);
		targetSize = new Vector3 (1.2f, 1.2f, 1);
	}

	// Update is called once per frame
	void Update () {
	
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();

		if (isCompleted && !isFlipped) {
			sprite.sprite = complete;
		}  
		else if (isFlipped) 
		{
			sprite.sprite = back;
		} 
		else 
		{
			sprite.sprite = front;
		}

	}

	void OnMouseOver()
	{
		if (!isActive) 
		{
			StartCoroutine(ScaleUpOverTime(.2f));

			isActive = true;
		}

		if (Input.GetMouseButtonDown (1))
		{
			isCompleted = !isCompleted;
		}
	}

	void OnMouseDown()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			StartCoroutine (FlipCard (.2f));
		}
	}

	void OnMouseExit()
	{
		StartCoroutine (ScaleDownOverTime (.2f));
		
		isActive = false;
	}

	IEnumerator ScaleUpOverTime(float time)
	{
		// zero the time
		float currentTime = 0.0f;
		
		do
		{
			// scale up and increase time each frame
			transform.localScale = Vector3.Lerp(startSize, targetSize, currentTime / time);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);
	}

	IEnumerator ScaleDownOverTime(float time)
	{
		// zero the time
		float currentTime = 0.0f;
		
		do
		{
			// scale up and increase time each frame
			transform.localScale = Vector3.Lerp(targetSize, startSize, currentTime / time);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);
	}

	IEnumerator FlipCard(float time)
	{
		// set the current size and target size
		Vector3 originalScale = new Vector3 (1.2f, 1.2f, 1);
		Vector3 destinationScale = new Vector3(0, 1.2f, 1);
		
		// zero the time
		float currentTime = 0.0f;
		
		do
		{
			// scale up and increase time each frame
			transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);

		isFlipped = !isFlipped;

		// zero the time
		currentTime = 0.0f;
		
		do
		{
			// scale up and increase time each frame
			transform.localScale = Vector3.Lerp(destinationScale, originalScale, currentTime / time);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);

	}

}
