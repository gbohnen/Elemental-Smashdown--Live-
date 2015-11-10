using UnityEngine;
using System.Collections;

public class CardRotating : MonoBehaviour {

	public GameObject rotatingCard;
	public GameObject prefabCard;

	public Sprite back;
	public Sprite face0;
	public Sprite face1;
	public Sprite face2;
	public Sprite face3;
	public Sprite face4;

	float timer = 0;
	public float rotationTime;

	public void Awake()
	{
		rotatingCard = Instantiate (prefabCard);

		rotatingCard.GetComponent<Card>().flipped = false;
		rotatingCard.GetComponent<Card> ().back = back;
		rotatingCard.GetComponent<Card>().sprite = face0;

		rotatingCard.transform.position = new Vector3 (3, -.9f);
	}

	public void Update()
	{
		timer += Time.deltaTime;

		if (timer >= rotationTime * 2.1) 
		{
			StartCoroutine(FlipCard(rotatingCard.GetComponent<Card>(), rotationTime));
			timer = 0;
		}
	}

	IEnumerator FlipCard(Card temp, float time)
	{
		// set the current size and target size
		Vector3 originalScale = temp.transform.localScale;
		Vector3 destinationScale = new Vector3(0, temp.transform.localScale.y, 1);
		
		// zero the time
		float currentTime = 0.0f;
		
		do
		{
			// scale up and increase time each frame
			temp.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);
		
		temp.flipped = !temp.flipped;
		
		switch ((int)Random.Range (0, 5)) {
		case 0:
			rotatingCard.GetComponent<Card>().sprite = face0;
			break;
		case 1:
			rotatingCard.GetComponent<Card>().sprite = face1;
			break;
		case 2:
			rotatingCard.GetComponent<Card>().sprite = face2;
			break;
		case 3:
			rotatingCard.GetComponent<Card>().sprite = face3;
			break;
		case 4:
			rotatingCard.GetComponent<Card>().sprite = face4;
			break;
		default:
			break;
		}
		
		// zero the time
		currentTime = 0.0f;
		
		do
		{
			// scale up and increase time each frame
			temp.transform.localScale = Vector3.Lerp(destinationScale, originalScale, currentTime / time);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);

		timer = rotationTime * 2;
	}
}
