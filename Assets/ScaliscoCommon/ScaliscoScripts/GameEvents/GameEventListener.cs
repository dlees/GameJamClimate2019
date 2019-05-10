using System.Collections;using System.Collections.Generic;using UnityEngine;using UnityEngine.Events;public abstract class GameEventListener : MonoBehaviour {    [Tooltip("Event to register with.")]    public GameEvent Event;    private void OnEnable() {        Event.RegisterListener(this);    }    private void OnDisable() {        Event.UnregisterListener(this);    }

    public abstract void OnEventRaised(Anything anything);

}