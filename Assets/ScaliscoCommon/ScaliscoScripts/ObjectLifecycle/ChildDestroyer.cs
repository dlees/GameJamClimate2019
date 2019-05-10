using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDestroyer : MonoBehaviour {

    public static void DestroyChildren(GameObject go) {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform tran in go.transform) {
            children.Add(tran.gameObject);
        }
        children.ForEach(child => GameObject.Destroy(child));
    }

    public void destroyChildren() {
        destroyChildren(this.gameObject);
    }

    public void destroyChildren(GameObject go) {
        ChildDestroyer.DestroyChildren(go);
    }
}
