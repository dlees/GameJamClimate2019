using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeActiveWhenSatisfied : MonoBehaviour {
    public ConditionReference enableWhenCondition;

    public GameObject gameObjectToEnable;

    void Update() {
        gameObjectToEnable.SetActive(enableWhenCondition.isConditionSatisfied());

    }
}

