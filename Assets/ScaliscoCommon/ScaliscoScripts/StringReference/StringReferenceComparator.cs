using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringReferenceComparator : Condition {

    public enum CompareOperation {
        EXACT_MATCH,
        CONTAINS
    }

    public StringReference compared;
    public CompareOperation operation = CompareOperation.EXACT_MATCH;
    public StringReference comparedWith;

    public override bool isConditionSatisfied() {

        switch (operation) {
            case CompareOperation.EXACT_MATCH:
                return compared.Value.Equals(comparedWith.Value);
            case CompareOperation.CONTAINS:
                return compared.Value.Contains(comparedWith.Value);
            default:
                throw new KeyNotFoundException("Compared Operation doesn't exist");
        }

    }
}
