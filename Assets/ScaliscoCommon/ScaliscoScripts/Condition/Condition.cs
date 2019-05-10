using UnityEngine;
using System.Collections;


abstract public class Condition : MonoBehaviour, Valueable<bool> {
    public abstract bool isConditionSatisfied();

    public bool Value {
        get { return isConditionSatisfied(); }
        set { throw new System.NotImplementedException(); }
    }

}
