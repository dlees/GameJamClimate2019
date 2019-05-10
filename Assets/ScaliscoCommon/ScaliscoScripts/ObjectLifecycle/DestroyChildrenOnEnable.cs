using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChildrenOnEnable : MonoBehaviour {

    void OnEnable() {
        ChildDestroyer.DestroyChildren(this.gameObject);

    }
}
