using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D body;    

    private float horizontal;
    private float vertical;
    public float accel = 0.025f;
    public float turnSpeed = 2f;
    public float maxSpeed = 2f;
    public float moveLimiter = 0.7f;
    
    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void FixedUpdate() {
        //if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        //{
        //    // limit movement speed diagonally, so you move at 70% speed
        //    horizontal *= moveLimiter;
        //    vertical *= moveLimiter;
        //}

        //body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        //if up pressed
        if (vertical > 0)
        {
            //add force
            body.AddRelativeForce(Vector2.up * accel);

            //if we are going too fast, cap speed
            if (body.velocity.magnitude > maxSpeed)
            {
                body.velocity = body.velocity.normalized * maxSpeed;
            }
        }

        //if right/left pressed add torque to turn
        if (Mathf.Abs(horizontal) > 0.0001f)
        {
            //scale the amount you can turn based on current velocity so slower turning below max speed
            float scale = Mathf.Lerp(0f, turnSpeed, body.velocity.magnitude / maxSpeed);
            //axis is opposite what we want by default
            body.AddTorque(-Input.GetAxis("Horizontal") * scale);
        }
    }
}