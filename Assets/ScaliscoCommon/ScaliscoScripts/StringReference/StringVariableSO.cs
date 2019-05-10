using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringVariableSO : ScriptableObject, Valueable<string>, MementoHolder {
    public string stringVar;

    public string Value {
        get { return stringVar; }
        set { stringVar = value; }
    }

    public void set(StringVariable variable) {
        Value = variable.Value;
    }

    [System.Serializable]
    class MyMemento : Memento {
        public string stringVar;

        public MyMemento(StringVariableSO variable) {
            stringVar = variable.stringVar;
        }
    }

    public Memento getMemento() {
        return new MyMemento(this);
    }

    public void loadFromMemento(Memento memento) {
        MyMemento myMemento = (MyMemento)memento;

        stringVar = myMemento.stringVar;
    }
}
