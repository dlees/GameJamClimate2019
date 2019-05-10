using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceUpdatedChecker<T, REFERENCE> where REFERENCE : Valueable<T> {

    private T lastValue = default;
    private bool isFirstCall = true;

    public bool hasBeenUpdated(REFERENCE reference) {
        bool hasBeenUpdated = (!reference.Value.Equals(lastValue) || isFirstCall);

        if (hasBeenUpdated) {
            lastValue = reference.Value;
            isFirstCall = false;
        }

        return hasBeenUpdated;
    }
}
