using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class CompositeConditionSO : ConditionSO {
    public enum LogicalOperator {
        ALL, ANY
    };
    public LogicalOperator logicalOperator = LogicalOperator.ALL;

    public List<ConditionReference> conditions = new List<ConditionReference>();

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


    public void addCondition(ConditionSO condition) {
        conditions.Add(new ConditionReference(condition));
    }

    public void removeCondition(ConditionSO condition) {
        conditions.Remove(new ConditionReference(condition));
    }
}
