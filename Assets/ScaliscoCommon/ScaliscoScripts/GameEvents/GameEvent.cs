using System.Collections;using System.Collections.Generic;using UnityEngine;public class GameEvent : ScriptableObject {    /// <summary>    /// The list of listeners that this event will notify if it is raised.    /// </summary>    private readonly List<GameEventListener> eventListeners =        new List<GameEventListener>();

#if UNITY_EDITOR
    [Multiline]
    [Tooltip("Try to include keys and types that are expected in the Anything object")]
    public string DeveloperDescription = "";
#endif
    public void Raise(Anything anything) {        for (int i = eventListeners.Count - 1; i >= 0; i--)             eventListeners[i].OnEventRaised(anything);    }


    public void Raise() {        Raise(null);    }    public void RegisterListener(GameEventListener listener) {        if (!eventListeners.Contains(listener))            eventListeners.Add(listener);    }    public void UnregisterListener(GameEventListener listener) {        if (eventListeners.Contains(listener))            eventListeners.Remove(listener);    }}