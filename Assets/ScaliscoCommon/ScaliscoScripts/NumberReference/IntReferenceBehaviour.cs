using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IntCallback : SerializableCallback<int> { }

[System.Serializable]
public class IntReference : GenericReferenceWithCallback<int, IntReferenceSO, IntReferenceBehaviour, IntCallback> {
    public void increment(int i) {
        Value += i;
    }
    public void increment(IntReferenceBehaviour i) {
        Value += i.Value;
    }
    public void increment(IntReferenceSO i) {
        Value += i.Value;
    }
    public void increment(IntReference i) {
        Value += i.Value;
    }
}

public class IntReferenceSO : ScriptableObject, Valueable<int> {
    public IntReference reference;
    public int Value { get => reference.Value; set => reference.Value = value; }

    public void increment(int i) {
        Value += i;
    }
    public void increment(IntReferenceBehaviour i) {
        Value += i.Value;
    }
    public void increment(IntReferenceSO i) {
        Value += i.Value;
    }
    public void increment(IntReference i) {
        Value += i.Value;
    }
}

public class IntReferenceBehaviour : GenericReferenceBehaviour<int, IntReference>
{
    public void increment(int i) {
        Value += i;
    }
    public void increment(IntReferenceBehaviour i) {
        Value += i.Value;
    }
    public void increment(IntReferenceSO i) {
        Value += i.Value;
    }
    public void increment(IntReference i) {
        Value += i.Value;
    }
}

