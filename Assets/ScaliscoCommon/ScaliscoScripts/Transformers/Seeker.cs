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

    // Physics movement variables
    public Rigidbody2D body;
    public float minDistanceToTarget = 1f;
    public float accel;
    public float turnSpeed;
    public float maxSpeed;

    void Start() {
        if (objectToMove == null) {
            objectToMove = this.gameObject.transform;
            body = GetComponent<Rigidbody2D>();
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
        Quaternion q = Quaternion.AngleAxis(angleToTarget(), Vector3.forward);
        return Quaternion.Slerp(transform.rotation, q, 1.0f);

    }

    private float angleToTarget()
    {
        Vector3 vectorToTarget = destination.transform.position - transform.position;
        return Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
    }

    public void changeDestination(GameObject newDestination) {
		destination = newDestination;
	}

    void MoveTowards(float moveSpeed)
    {

        //if up pressed
        if (DistanceToTarget() > minDistanceToTarget)
        {
            //add force
            body.AddRelativeForce(Vector2.up * accel);

            //if we are going too fast, cap speed
            if (body.velocity.magnitude > moveSpeed)
            {
                body.velocity = body.velocity.normalized * moveSpeed;
            }
        }
        float newRotation = angleToTarget();
        //if right/left pressed add torque to turn
        if (Mathf.Abs(newRotation) > 0.001f)
        {
            //scale the amount you can turn based on current velocity so slower turning below max speed
            float scale = Mathf.Lerp(0f, turnSpeed, body.velocity.magnitude / maxSpeed);
            //axis is opposite what we want by default
            body.AddTorque(-newRotation * scale);
        }
    }

    float DistanceToTarget()
    {
        return Vector3.Distance(destination.transform.position, transform.position);
    }
}
