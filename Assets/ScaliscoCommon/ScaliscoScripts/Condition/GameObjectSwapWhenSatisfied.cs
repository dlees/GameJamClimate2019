using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSwapWhenSatisfied : MonoBehaviour {

    public Condition condition;
    public GameObject enabledWhenSatisfied;
    public GameObject enabledWhenDisatisfied;

    void Update () {
        bool isSatisfied = condition.isConditionSatisfied();
        enabledWhenSatisfied.SetActive(isSatisfied);
        enabledWhenDisatisfied.SetActive(!isSatisfied);
    }
}
