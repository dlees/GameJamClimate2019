using System.Collections;using System.Collections.Generic;using UnityEngine;using UnityEngine.Events;
public class UnityEventGameEventListener : GameEventListener {
    [Tooltip("Optional data that is added from event.")]    public Anything eventData;

    [Tooltip("Response to invoke when Event is raised.")]    public UnityEvent Response;
    public override void OnEventRaised(Anything anything) {
        if (anything != null && eventData != null) {
            eventData.copyFrom(anything);
        }        Response.Invoke();    }}