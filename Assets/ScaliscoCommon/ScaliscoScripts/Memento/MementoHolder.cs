using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MementoHolder {
    Memento getMemento();

    void loadFromMemento(Memento memento);

}
