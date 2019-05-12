using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectileHit : MonoBehaviour {

    public FloatReference healthVariableToDecrement;
    public float probabilityToBeHurt = 0.05f;
    public float amountToLose;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "WaterProjectile") {
            if (Random.Range(0f,1f) < probabilityToBeHurt)
                healthVariableToDecrement.Value -= amountToLose;
        }
    }
}
