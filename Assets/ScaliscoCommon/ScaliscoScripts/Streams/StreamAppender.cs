using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StreamAppender : MonoBehaviour {
    public abstract void addToStream(string str);
}