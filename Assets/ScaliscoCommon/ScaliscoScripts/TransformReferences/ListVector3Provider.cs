using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListVector3Provider : Vector3Provider {

    public GameObject[] positions;

    public int curIndex;
    public bool startOnRandom;

    void Start() {
        if (startOnRandom) {
            pickRandomPosition();
        }
    }
    
    public override Vector3 Value {
        get {
            return positions[curIndex].transform.position;
        }

        set {
            throw new System.NotImplementedException();
        }
    }

    public void incrementThroughList() {
        curIndex = (curIndex + 1) % positions.Length;
    }

    public void pickRandomPosition() {
        curIndex = Random.Range(0, positions.Length);
    }

}
