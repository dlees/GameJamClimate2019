using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class OnDestroyEventWhenSatisfied : MonoBehaviour {

    public ConditionReference condition;
    public UnityEvent unityEvent;

    void OnDestroy() {
        if (condition.isConditionSatisfied()) {
            unityEvent.Invoke();
        }
    }

}
