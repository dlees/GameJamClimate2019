using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class RuntimeSet<T> : ScriptableObject, Valueable<List<T>>, IList<T>, ListenerSubject<ListReferenceListener<T>> {

    private void OnEnable() {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

    [SerializeField]
    public List<T> Items = new List<T>();

    private ListListenerSubject<T> listenerSubject = new ListListenerSubject<T>();

    public List<T> Value {
        get {
            return Items;
        }

        set {
            Items = value;
        }
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
