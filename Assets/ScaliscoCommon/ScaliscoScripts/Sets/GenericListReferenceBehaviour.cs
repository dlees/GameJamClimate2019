using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericListReferenceBehaviour<T, REFERENCE> : MonoBehaviour, Valueable<List<T>>, IList<T>, ListenerSubject<ListReferenceListener<T>>
    where REFERENCE : Valueable<List<T>> {

    public REFERENCE reference;

    private ListListenerSubject<T> listenerSubject = new ListListenerSubject<T>();

    public List<T> Value {
        get {
            return reference.Value;
        }

        set {
            reference.Value = value;
        }
    }

    public void setReference(REFERENCE newReference) {
        reference = newReference;
        
        /// TODO: Update Listeners somehow?
        /// 
        // Remove me from my current refs listeners
        // Add me to new one's
        // Let my listeners know the new list.
    }

    public void setReference(GenericListReferenceBehaviour<T, REFERENCE> newReference) {
        setReference(newReference.reference);
    }
   
    public T this[int index] {
        get { return Value[index]; }
        set { Value[index] = value; }
    }

    public int Count {
        get {
            return Value.Count;
        }
    }

    public bool IsReadOnly {
        get {
            return false;
        }
    }

    public bool Contains(T item) {
        return Value.Contains(item);
    }

    public int IndexOf(T item) {
        return Value.IndexOf(item);
    }

    public void CopyTo(T[] array, int arrayIndex) {
        Value.CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator() {
        return Value.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return Value.GetEnumerator();
    }
    #region WRITE_OPERATIONS
    public void Add(T thing) {
        listenerSubject.Add(Value, thing);
    }

    public void Remove(T thing) {
        listenerSubject.Remove(Value, thing);
    }

    public void Clear() {
        listenerSubject.Clear(Value);
    }

    public void Insert(int index, T item) {
        listenerSubject.Insert(Value, index, item);
    }

    public void RemoveAt(int index) {
        listenerSubject.RemoveAt(Value, index);
    }

    bool ICollection<T>.Remove(T item) {
        return listenerSubject.RemoveAndReport(Value, item);
    }
    #endregion WRITE_OPERATIONS

    public void addListener(ListReferenceListener<T> listener) {
        listenerSubject.addListener(listener);
    }

    public void removeListener(ListReferenceListener<T> listener) {
        listenerSubject.removeListener(listener);
    }
}

public class GenericListReference<CONSTANT_TYPE, SO_TYPE, MB_TYPE> : GenericReference<List<CONSTANT_TYPE>, SO_TYPE, MB_TYPE>, IList<CONSTANT_TYPE>
where SO_TYPE : Valueable<List<CONSTANT_TYPE>>, IList<CONSTANT_TYPE>
where MB_TYPE : Valueable<List<CONSTANT_TYPE>>, IList<CONSTANT_TYPE> {


    public GenericListReference(List<CONSTANT_TYPE> list) : base(list) {
    }
    public GenericListReference(SO_TYPE reference) : base(reference) {
    }
    public GenericListReference(MB_TYPE reference) : base(reference) {
    }
    public GenericListReference(GenericListReference<CONSTANT_TYPE, SO_TYPE, MB_TYPE> reference) : base(reference) {
    }

    public CONSTANT_TYPE this[int index] {
        get { return Value[index]; }
        set { Value[index] = value; }
    }

    public int Count {
        get {
            return Value.Count;
        }
    }

    public bool IsReadOnly {
        get {
            return false;
        }
    }

    public void Add(CONSTANT_TYPE item) {
        switch (chosenType) {
            case Type.CONSTANT:
                ConstantValue.Add(item);
                break;
            case Type.SCRIPTABLE_OBJECT:
                scriptableObjectVariable.Add(item);
                break;
            case Type.MONO_BEHAVIOUR:
                monoBehaviourVariable.Add(item);
                break;
            default:
                Value.Add(item);
                break;
        }
    }

    public void Clear() {
        switch (chosenType) {
            case Type.CONSTANT:
                ConstantValue.Clear();
                break;
            case Type.SCRIPTABLE_OBJECT:
                scriptableObjectVariable.Clear();
                break;
            case Type.MONO_BEHAVIOUR:
                monoBehaviourVariable.Clear();
                break;
            default:
                Value.Clear();
                break;
        }
    }

    public bool Contains(CONSTANT_TYPE item) {
        return Value.Contains(item);
    }

    public void CopyTo(CONSTANT_TYPE[] array, int arrayIndex) {
        Value.CopyTo(array, arrayIndex);
    }

    public IEnumerator<CONSTANT_TYPE> GetEnumerator() {
        return Value.GetEnumerator();
    }

    public int IndexOf(CONSTANT_TYPE item) {
        return Value.IndexOf(item);
    }

    public void Insert(int index, CONSTANT_TYPE item) {
        switch (chosenType) {
            case Type.CONSTANT:
                ConstantValue.Insert(index, item);
                break;
            case Type.SCRIPTABLE_OBJECT:
                scriptableObjectVariable.Insert(index, item);
                break;
            case Type.MONO_BEHAVIOUR:
                monoBehaviourVariable.Insert(index, item);
                break;
            default:
                Value.Insert(index, item);
                break;
        }
    }

    public bool Remove(CONSTANT_TYPE item) {
        switch (chosenType) {
            case Type.CONSTANT:
                return Value.Remove(item);
            case Type.SCRIPTABLE_OBJECT:
                return scriptableObjectVariable.Remove(item);
            case Type.MONO_BEHAVIOUR:
                return monoBehaviourVariable.Remove(item);
            default:
                return Value.Remove(item);
        }
    }

    public void RemoveAt(int index) {
        switch (chosenType) {
            case Type.CONSTANT:
                ConstantValue.RemoveAt(index);
                break;
            case Type.SCRIPTABLE_OBJECT:
                scriptableObjectVariable.RemoveAt(index);
                break;
            case Type.MONO_BEHAVIOUR:
                monoBehaviourVariable.RemoveAt(index);
                break;
            default:
                Value.RemoveAt(index);
                break;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return Value.GetEnumerator();
    }
    
}
