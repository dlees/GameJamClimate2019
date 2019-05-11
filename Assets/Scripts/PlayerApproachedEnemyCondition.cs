using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerApproachedEnemyCondition : Condition
{
    private bool isApproached = false;
    private GameObject enemyApproached = null;

    private float timeInCollider = 0 ;

    public override bool isConditionSatisfied() {
        return timeInCollider > 2.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        enemyApproached = collision.gameObject;
        isApproached = true;
    }
    private void OnTriggerExit2D(Collider2D collision) {
        isApproached = false;
        enemyApproached = null;
        timeInCollider = 0;
    }

     void Update() {
        if (isApproached) {
            timeInCollider += Time.deltaTime;
        }
    }
}
