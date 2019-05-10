using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class CompositeCondition : Condition {
    public List<Condition> conditions;
    // Ideally this would be a reference that we can add/remove from seperately
    // Thus abstracting out the list funcitons.

    public enum LogicalOperator {
        ALL, ANY
    };
    public LogicalOperator logicalOperator = LogicalOperator.ALL;

    public override bool isConditionSatisfied() {
        switch (logicalOperator) {
            case LogicalOperator.ALL:
                return conditions.TrueForAll(c => c.isConditionSatisfied());
             case LogicalOperator.ANY:
                return conditions.Any(c => c.isConditionSatisfied());
            default:
                throw new KeyNotFoundException("Logical Operator not found");
            }
    }


    public void addCondition(Condition condition) {
        conditions.Add(condition);
    }

    public void removeCondition(Condition condition) {
        conditions.Remove(condition);
    }
}
