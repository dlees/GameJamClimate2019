using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerApproachedEnemyCondition : Condition
{
    private bool isApproached = false;
    private GameObject enemyApproached = null;

    public override bool isConditionSatisfied() {
        return isApproached;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        enemyApproached = collision.gameObject;
        isApproached = true;
    }
    private void OnTriggerExit2D(Collider2D collision) {
        isApproached = false;
        enemyApproached = null;
    }

}
