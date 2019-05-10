using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatVariableSnapshotter : MonoBehaviour {

    public List<FloatVariable> variables;
    public List<StreamAppender> streams;
    public float repeatRateSeconds = 10.0f;

    void Start () {
        InvokeRepeating("snapshotToStream", 0.0f, repeatRateSeconds);
	}
	
	public void snapshotToStream() {
        System.DateTime nowdateTime = System.DateTime.Now.ToUniversalTime();
        string snapshot = nowdateTime.ToShortDateString() + ";" +
            nowdateTime.ToShortTimeString() + ";" +
            string.Join(";", ContainerConverter.toStringList(variables));

        streams.ForEach(stream => stream.addToStream(snapshot));
    }
}
