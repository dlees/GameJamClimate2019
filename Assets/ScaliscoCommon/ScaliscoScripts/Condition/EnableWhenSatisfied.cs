using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnableWhenSatisfied : MonoBehaviour {

    public Condition enableWhenSatisfied;
    public MonoBehaviour component;

    void Update() {
        component.enabled = enableWhenSatisfied.isConditionSatisfied();

    }
}

