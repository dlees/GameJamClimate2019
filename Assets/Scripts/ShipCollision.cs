using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : MonoBehaviour
{
    public FloatReference healthVariableToDecrement;
    public float collisionSpeedLower;
    public float collisionSpeedHigher;

    //Rigidbody2D body;

    public ShakeCameraControl shaker;

    private void Start()
    {
        //body = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            float relativeSpeed = other.relativeVelocity.magnitude;
            Debug.Log("Relative speed:" + relativeSpeed);
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
