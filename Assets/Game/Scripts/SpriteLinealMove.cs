using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLinealMove : MonoBehaviour {

	public float initialWait = 0.0F;
	public Vector3 startPosition;
	public Vector3 endPosition;
	public float speed = 1.0F;

	private float startTime;
	private float journeyLength;
	private bool  start;

	IEnumerator Start(){

		if( initialWait > 0.0F )
			yield return new WaitForSeconds(initialWait);

		startTime = Time.time;
		journeyLength = Vector3.Distance(startPosition, endPosition);
		yield return null;

		while (!startPosition.Equals(endPosition)){
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;

			//GetComponent<RectTransform>().localPosition = Vector3.Lerp(startPosition, endPosition, fracJourney);
			transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);

			yield return null;
		}
	}


}

