using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D body;
    public AudioSource engineAudioSource;
    private float horizontal;
    private float vertical;
    public float accel;
    public float turnSpeed;
    public float maxSpeed;

    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void FixedUpdate() {

        //if up pressed
        if (vertical != 0)
        {
            //add force
            body.AddRelativeForce(Vector2.up * accel * vertical);

            //if we are going too fast, cap speed
            if (body.velocity.magnitude > maxSpeed)
            {
                body.velocity = body.velocity.normalized * maxSpeed;
            }

        } 
        engineAudioSource.pitch = (0.15f + (body.velocity.magnitude / maxSpeed) * 2.75f);

        //if right/left pressed add torque to turn
        if (Mathf.Abs(horizontal) > 0.001f)
        {
            //scale the amount you can turn based on current velocity so slower turning below max speed
            float scale = Mathf.Lerp(0f, turnSpeed, body.velocity.magnitude / maxSpeed);
            //axis is opposite what we want by default
            body.AddTorque(-Input.GetAxis("Horizontal") * scale);
        }
    }
}