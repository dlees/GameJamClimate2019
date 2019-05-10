using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class StringContainedInSetCondition: Condition {

    public StringReference stringToLookFor;
    public StringSet stringSet;
    public bool matchCase = true;
    public bool partialMatch = false;

    private StringComparer comparer;
    private StringComparison comparison;

    void Start() {
        if (matchCase) {
            comparer = StringComparer.Ordinal;
            comparison = StringComparison.Ordinal;
        } else {
            comparer = StringComparer.OrdinalIgnoreCase;
            comparison = StringComparison.OrdinalIgnoreCase;

        }
    }

    public override bool isConditionSatisfied() {
        if (partialMatch) {
            return stringSet.Items.Any(str => stringToLookFor.Value.IndexOf(str, comparison) >= 0);
        } else {
            return stringSet.Items.Contains(stringToLookFor, comparer);
        }
    }
}
