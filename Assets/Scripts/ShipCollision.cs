using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : MonoBehaviour
{
    public FloatReference healthVariableToDecrement;
    public float collisionSpeedLower;
    public float collisionSpeedHigher;

    Rigidbody2D body;

    public ShakeCameraControl shaker;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            float relativeSpeed = Vector2.SqrMagnitude(body.velocity -
                other.GetComponent<Rigidbody2D>().velocity);
            Debug.Log("Colided with other at speed: " + relativeSpeed);
            if (relativeSpeed > collisionSpeedLower) {
                healthVariableToDecrement.Value = 0;
                // TODO: add small ship explosion
            }
            if (relativeSpeed > collisionSpeedHigher)
            {
                // TODO: add other ship explosion
            }
            shaker.Shake(relativeSpeed/2, 5, 10);
        }
    }
}
