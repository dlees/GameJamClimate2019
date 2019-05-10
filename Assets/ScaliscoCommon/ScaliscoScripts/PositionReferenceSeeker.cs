
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PositionReferenceSeeker : MonoBehaviour {

    public Vector3Reference destination;
    public float speed = 20.0f;

	public UnityEvent unityEvent;

	private Transform objectToMove;

	void Start() {
		objectToMove = this.gameObject.transform;
        speed *= Screen.height / 600;
	}

	void Update() {
		objectToMove.position = Vector3.MoveTowards (objectToMove.position, destination, speed);

        objectToMove.rotation = getNewRotation();

		if (objectToMove.position.FuzzyEquals(destination.Value)) {
			unityEvent.Invoke();
        } 	
    }

    private Quaternion getNewRotation() {
        Vector3 vectorToTarget = destination - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        return Quaternion.Slerp(transform.rotation, q, 1.0f);

    }
}
