using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFromListIndex : MonoBehaviour
{
    public TransformListReference transforms;

    public int curIndex;
    public bool startOnRandom;

    void Start() {
        if (startOnRandom) {
            pickRandomPosition();
        }
    }

    public void incrementThroughList() {
        curIndex = (curIndex + 1) % transforms.Value.Count;
    }

    public void pickRandomPosition() {
        curIndex = Random.Range(0, transforms.Value.Count);
    }
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = transforms[curIndex].position;
    }
}
