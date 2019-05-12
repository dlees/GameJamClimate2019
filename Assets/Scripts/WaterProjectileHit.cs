using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectileHit : MonoBehaviour {

    public FloatReference healthVariableToDecrement;
    public float probabilityToBeHurt = 0.05f;
    public float delayBetweenHits = 0.5f;
    public float timeBetweenProjectiles = 0.05f;
    public float timeFromLastHit = 0f;
    public float amountToLose;

    private void Update()
    {
        timeFromLastHit += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other) { 
        if (other.CompareTag("WaterProjectile") && timeFromLastHit > timeBetweenProjectiles) {
            if (Random.Range(0f,1f) < probabilityToBeHurt)
                healthVariableToDecrement.Value -= amountToLose;
            timeFromLastHit = 0;
        }
    }
}
