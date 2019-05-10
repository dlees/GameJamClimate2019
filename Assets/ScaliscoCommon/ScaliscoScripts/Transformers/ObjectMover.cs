using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour {

	public Transform objectToMove;
	public float speed = 20.0f;

	private Vector3 posToMoveTo;

	void Start() {
		posToMoveTo = objectToMove.position;
	}

	void Update() {
		objectToMove.position = Vector3.MoveTowards (objectToMove.position, posToMoveTo, speed * Screen.height/600);
	}

	public void moveToPosition(Transform placeToMoveTo) {
		posToMoveTo = placeToMoveTo.position;
	}

}
