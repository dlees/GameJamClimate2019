using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DEPRECATED - Use CompositeCondition instead
public class DeprecatedCompositeConditionAll : Condition {
    public List<Condition> conditions;
    // Ideally this would be a reference that we can add/remove from seperately
    // Thus abstracting out the list funcitons.
	
    public override bool isConditionSatisfied()
    {
        return conditions.TrueForAll(c => c.isConditionSatisfied());
    }

    public void addCondition(Condition condition) {
        conditions.Add(condition);
    }

    public void removeCondition(Condition condition) {
        conditions.Remove(condition);
    }
}
