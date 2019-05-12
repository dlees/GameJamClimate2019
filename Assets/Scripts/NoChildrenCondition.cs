using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoChildrenCondition : Condition
{

    public Transform parent;

    public override bool isConditionSatisfied() {
        return parent.childCount == 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        parent = this.gameObject.transform;   
    }


}
