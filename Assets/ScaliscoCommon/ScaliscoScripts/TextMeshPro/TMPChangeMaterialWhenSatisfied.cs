using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPChangeMaterialWhenSatisfied : MonoBehaviour
{
    public Condition enableWhenSatisfied;
    public TextMeshProUGUI text;
    public Material materialWhenSatisfied;
    public Material materialWhenUnsatisfied;

    private void Start() {
        if (materialWhenUnsatisfied == null) {
            materialWhenUnsatisfied = text.fontMaterial;
        }
    }

    void Update() {
        if (enableWhenSatisfied.isConditionSatisfied()) {
            text.fontMaterial = materialWhenSatisfied; 
        } else {
            text.fontMaterial = materialWhenUnsatisfied;
        }
    }
}
