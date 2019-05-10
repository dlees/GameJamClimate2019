using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugStreamAppender : StreamAppender {
    public override void addToStream(string str) {
        Debug.Log(str);
    }

}
