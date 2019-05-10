using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuaternionReference : GenericReference<Quaternion, QuaternionSO, QuaternionProvider> {
    public QuaternionReference(Quaternion value) : base(value) { }
}

public class QuaternionSO : ScriptableObject, Valueable<Quaternion> {
    public Quaternion Quaternion;
    public Quaternion Value {
        get {
            return Quaternion;
        }

        set {
            Quaternion = value;
        }
    }
}

public class QuaternionProvider : MonoBehaviour, Valueable<Quaternion> {
    public Quaternion vector;

    public Quaternion Value {
        get {
            return vector;
        }

        set {
            throw new System.NotImplementedException();
        }
    }

}
