using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIntLoader : MonoBehaviour
{
    public FloatReference min;
    public FloatReference max;

    public void loadRandomNumber(FloatReferenceBehaviour destination) {
        destination.Value = Random.Range(min, max);
    }
}
