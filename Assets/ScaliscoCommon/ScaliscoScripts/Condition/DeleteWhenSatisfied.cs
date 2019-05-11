using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWhenSatisfied : MonoBehaviour {
    public ConditionReference condition;

    void Update() {
        if (condition.isConditionSatisfied()) {
            Destroy(this.gameObject);
        }

    }
}
