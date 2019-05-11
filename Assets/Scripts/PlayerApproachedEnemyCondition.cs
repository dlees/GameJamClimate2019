using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerApproachedEnemyCondition : Condition
{
    private bool isApproached = false;
    private GameObject enemyApproached = null;

    public FloatReference timeInCollider;
    public FloatReference timeRequiredToBoard;

    public override bool isConditionSatisfied() {
        return timeInCollider.Value > timeRequiredToBoard.Value;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        enemyApproached = collision.gameObject;
        isApproached = true;
    }
    private void OnTriggerExit2D(Collider2D collision) {
        isApproached = false;
        enemyApproached = null;
        timeInCollider.Value = 0;
    }

     void Update() {
        if (isApproached) {
            timeInCollider.Value += Time.deltaTime;
        }
    }
}
