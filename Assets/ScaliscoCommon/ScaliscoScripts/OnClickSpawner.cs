using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.

public class OnClickSpawner : MonoBehaviour , IPointerUpHandler {

    public IncrementNotificationFactory factory;
    public ConditionReference condition = new ConditionReference(true);

    public void OnPointerUp(PointerEventData eventData) {
        if (condition.isConditionSatisfied()) {
            factory.createIncrementNotification(1, eventData.position);
        }
    }
}
