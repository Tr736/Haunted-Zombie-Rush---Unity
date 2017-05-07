using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour {

	[SerializeField] private float  objectSpeed = 1.0f;
	[SerializeField] private float  positionX = -85.0f;
	[SerializeField] private float resetPosition =  25.0f;

	
	// Update is called once per frame
	protected virtual void Update () {

		if (!GameManager.instance.gameOver){

			transform.Translate (Vector3.right * (objectSpeed * Time.deltaTime));

			if (transform.localPosition.x >= resetPosition){

				Vector3 newPos = new Vector3 (positionX, transform.position.y, transform.position.z);

				transform.position = newPos;
			}	
		}

	
	}
}
