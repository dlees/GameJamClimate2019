using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable] 
public class ChanceEvent {
    public FloatReference chance;
    public UnityEvent unityEvent;
}

public class RandomlyChosenEvent : MonoBehaviour {

    public List<ChanceEvent> chanceEvents;

    public float getTotal() {
        float total = 0;
        chanceEvents.ForEach(chanceEvent => total += chanceEvent.chance);
        return total;
    }

    public void trigger() {
        float total = getTotal();
        float chosenRandomNumber = Random.Range(0, total);

        float runningTotal = 0;
        foreach (ChanceEvent chanceEvent in chanceEvents) {
            runningTotal += chanceEvent.chance;
            if (chosenRandomNumber <= runningTotal) {
                chanceEvent.unityEvent.Invoke();
                return;
            }
        }
    }
}
