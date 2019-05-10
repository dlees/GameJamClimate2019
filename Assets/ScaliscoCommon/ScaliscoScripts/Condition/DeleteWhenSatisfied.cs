using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWhenSatisfied : MonoBehaviour {
    [System.Obsolete("Deprecated. Use the ConditionReference instead.")]
    public Condition deleteWhenSatisfied;
    public ConditionReference condition;

    // Use this for initialization
    void Start() {
        // ONLY here for backwards compatability.
        if (deleteWhenSatisfied != null) {
            condition = new ConditionReference(deleteWhenSatisfied);
        }
    }

    void Update() {
        if (condition.isConditionSatisfied()) {
            Destroy(this.gameObject);
        }

    }
}
