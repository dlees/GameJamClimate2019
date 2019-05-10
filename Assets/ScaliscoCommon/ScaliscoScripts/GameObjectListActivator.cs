using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectListActivator : MonoBehaviour {
    public List<GameObject> gameObjects;

    private int curIndex = 0;

    void Start() {
        gameObjects[curIndex].gameObject.SetActive(true);
    }

    public void nextObject() {
        gameObjects[curIndex++].gameObject.SetActive(false);

        curIndex %= gameObjects.Count;

        gameObjects[curIndex].gameObject.SetActive(true);
    }

    public void activateIndex(int i) {
        gameObjects[curIndex].gameObject.SetActive(false);
        curIndex = i;
        gameObjects[curIndex].gameObject.SetActive(true);
    }

    public int getIndex() {
        return curIndex;
    }
}
