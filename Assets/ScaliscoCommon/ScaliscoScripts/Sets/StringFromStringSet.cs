using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringFromStringSet : MonoBehaviour
{
    [SerializeField]
    private StringSetReference stringSet;

    private int curIndex = 0;

    public string getCurrentString() {
        return stringSet.Value[curIndex];
    }

    public void next() {
        curIndex = (curIndex + 1) % stringSet.Value.Count;
    }

    public void prev() {
        curIndex = (curIndex - 1) % stringSet.Value.Count;
    }
}
