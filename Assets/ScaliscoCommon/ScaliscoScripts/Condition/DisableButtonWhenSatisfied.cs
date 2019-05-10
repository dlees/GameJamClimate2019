using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableButtonWhenSatisfied : MonoBehaviour {

    public Condition disableWhenSatisfied;
    public Button button;

    // Use this for initialization
    void Start() {

    }

    void Update() {
        button.interactable = !disableWhenSatisfied.isConditionSatisfied();

    }
}
