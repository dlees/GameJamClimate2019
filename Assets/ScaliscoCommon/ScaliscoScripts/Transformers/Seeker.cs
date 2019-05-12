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

    public Transform destinationTransform;

    public UnityEvent unityEvent;
    public FloatReference speed;
    public RigidbodyForwardMovement movement;
    public float minDistanceToTarget = 1f;

    public bool shouldMoveAway = false;

    void Start() {
        if (objectToMove == null) {
            objectToMove = this.gameObject.transform;
        }
    }

    void Update() {
        Vector3 target = shouldMoveAway ? getAwayFromTarget(destinationTransform.position) : destinationTransform.position;
        movement.MoveTowards(speed, target, minDistanceToTarget);


        if (movement.DistanceToTarget(target) <= minDistanceToTarget) {
            unityEvent.Invoke();
        }
    }

    private Vector3 getAwayFromTarget(Vector3 oppositeTarget) {
        return objectToMove.position + (objectToMove.position - oppositeTarget).normalized * 1000;
    }

    public void changeDestination(Transform newDestination) {
        destinationTransform = newDestination;
    }
    
}
