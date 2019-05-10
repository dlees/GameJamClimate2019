using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolFlag : ScriptableObject, Valueable<bool>, MementoHolder {
    public bool flag = false;

    public bool Value {
        get {
            return flag;
        }
        set {
            flag = value;
        }
    }

    [System.Serializable]
    class MyMemento : Memento {
        public bool var;

        public MyMemento(BoolFlag variable) {
            var = variable.flag;
        }
    }

    public Memento getMemento() {
        return new MyMemento(this);
    }

    public void loadFromMemento(Memento memento) {
        flag = ((MyMemento)memento).var;
    }

    public void toggle() {
        flag = !flag;
    }

}
