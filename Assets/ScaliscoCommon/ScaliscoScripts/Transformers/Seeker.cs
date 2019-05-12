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

    public FrontCollisionAvoidance frontLeftCollisionAvoidance;
    public FrontCollisionAvoidance frontRightCollisionAvoidance;
    Vector3 target;

    void Start() {
        if (objectToMove == null) {
            objectToMove = this.gameObject.transform;
        }
    }

    void Update() {
        if (!frontLeftCollisionAvoidance.shouldEvade && !frontRightCollisionAvoidance)
            target = shouldMoveAway ? getAwayFromTarget(destinationTransform.position) : destinationTransform.position;
        else if (frontLeftCollisionAvoidance)
            target = objectToMove.position + objectToMove.right;
        else
            target = objectToMove.position - objectToMove.right;

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
