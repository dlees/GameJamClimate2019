using UnityEngine;
using System.Collections;


public class QuaternionFromTransformBehaviour : MonoBehaviour, Valueable<Quaternion> {
    public Transform tranform;

    public Quaternion Value {
        get {
            return tranform.rotation;
        }

        set {
            throw new System.NotImplementedException();
        }
    }

}
