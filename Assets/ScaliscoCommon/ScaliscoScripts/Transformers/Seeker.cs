using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Seeks towards a position and fires a UnityEvent when it reaches the destination.
 * 
 * */
public class Seeker : MonoBehaviour {
    public Transform objectToMove = null;
    public GameObject destination;
	public UnityEvent unityEvent;
	public FloatReference speed;

	void Start() {
        if (objectToMove == null) {
            objectToMove = this.gameObject.transform;
        }
	}

	void Update() {
		objectToMove.position = Vector3.MoveTowards (objectToMove.position, destination.transform.position, speed);

        objectToMove.rotation = getNewRotation();

		if (objectToMove.position == destination.transform.position) {
			unityEvent.Invoke();
        } 	
    }

    private Quaternion getNewRotation() {
        Vector3 vectorToTarget = destination.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        return Quaternion.Slerp(transform.rotation, q, 1.0f);

    }

	public void changeDestination(GameObject newDestination) {
		destination = newDestination;
	}
}
