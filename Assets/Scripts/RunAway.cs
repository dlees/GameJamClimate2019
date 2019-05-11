using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Seeks towards a position and fires a UnityEvent when it reaches the destination.
 * 
 * */
public class RunAway : MonoBehaviour {
    public Transform objectToMove = null;
    public GameObject objectToAvoid;
    public FloatReference speed;

    // Physics movement variables
    public RigidbodyForwardMovement movement;
    public float minDistanceToTarget = 1f;


    void Start() {
        if (objectToMove == null) {
            objectToMove = this.gameObject.transform;
        }
    }

    void Update() {
        Vector3 target = getAwayFromTarget();

        movement.MoveTowards(speed, target, minDistanceToTarget);
    }

    private Vector3 getAwayFromTarget() {
        return 2 * objectToMove.position - objectToAvoid.transform.position;
    }


    public void changeDestination(GameObject newDestination) {
        objectToAvoid = newDestination;
    }



}
