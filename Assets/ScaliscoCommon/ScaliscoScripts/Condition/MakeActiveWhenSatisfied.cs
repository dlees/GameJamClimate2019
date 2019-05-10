using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeActiveWhenSatisfied : MonoBehaviour {

    [System.Obsolete("Deprecated. Use the ConditionReference instead.")]
    public Condition enableWhenSatisfied;

    public ConditionReference enableWhenCondition;

    public GameObject gameObjectToEnable;


    void Start() {
        // ONLY here for backwards compatability.
        if (enableWhenSatisfied != null) {
            enableWhenCondition = new ConditionReference(enableWhenSatisfied);
        }
    }

    void Update() {
        gameObjectToEnable.SetActive(enableWhenCondition.isConditionSatisfied());

    }
}

