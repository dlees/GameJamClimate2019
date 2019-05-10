using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapFrequencyCalculator : MonoBehaviour {

    private Queue<float> taps = new Queue<float>();
    public FloatReference tapsPerSecond;

    public void addTap() {
        taps.Enqueue(Time.timeSinceLevelLoad);
    }

    void Update() {
         while (taps.Count > 0 && taps.Peek() <= Time.timeSinceLevelLoad - 1) {
            taps.Dequeue();
        }
        
        tapsPerSecond.setValue(taps.Count);
    }
}