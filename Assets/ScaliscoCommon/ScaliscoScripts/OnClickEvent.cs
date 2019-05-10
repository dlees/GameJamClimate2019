using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.
using UnityEngine.Events;

public class OnClickEvent : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

    public UnityEvent eventOnPointerUp;
    public UnityEvent eventOnPointerDown;

    public void OnPointerUp(PointerEventData eventData) {
        eventOnPointerUp.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData) {
        eventOnPointerDown.Invoke();

    }
}