using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaterProjectileHit : MonoBehaviour {

    public FloatReference healthVariableToDecrement;
    public float probabilityToBeHurt = 0.50f;
    public float timeBetweenProjectiles = 0.05f;
    public float timeFromLastHit;
    public float timeToGainWaterProtection = 10f;
    public float amountToLose;

    public UnityEvent eventOnHit;
    public UnityEvent eventOnDamage;

    private void Start()
    {
        timeFromLastHit = timeToGainWaterProtection;
    }

    private void Update() {
        timeFromLastHit += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("WaterProjectile") && timeFromLastHit > timeBetweenProjectiles) {

            if (Random.Range(0f, 1f) < probabilityToBeHurt && timeFromLastHit < timeToGainWaterProtection) {
                healthVariableToDecrement.Value -= amountToLose;
                eventOnDamage.Invoke();
            }
            timeFromLastHit = 0;
            eventOnHit.Invoke();
        }
    }
}
 

