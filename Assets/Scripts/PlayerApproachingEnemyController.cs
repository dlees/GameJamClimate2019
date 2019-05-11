using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerApproachingEnemyController : Condition
{

    private bool isAbleToBoard = false;
    public override bool isConditionSatisfied() {
        return isAbleToBoard;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        isAbleToBoard = true;
    }
    private void OnTriggerExit2D(Collider2D collision) {
        isAbleToBoard = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
