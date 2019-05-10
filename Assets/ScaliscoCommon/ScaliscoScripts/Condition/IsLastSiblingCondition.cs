using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLastSiblingCondition : Condition { 
    public RectTransform transformToCheck;

    public override bool isConditionSatisfied() {
        return transformToCheck.GetSiblingIndex() == transformToCheck.parent.childCount-1;
    }
}
