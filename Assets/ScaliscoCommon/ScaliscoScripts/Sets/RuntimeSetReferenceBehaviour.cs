using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// DEPRECATED! Use GenericListReference/GenericListReferenceBehaviour because it contains listeners.
/// </summary>
/// <typeparam name="T"></typeparam>
public class RuntimeSetReference<T> : GenericReference<List<T>, RuntimeSet<T>, RuntimeSetReferenceBehaviour<T>> { }

public class RuntimeSetReferenceBehaviour<T> : GenericReferenceBehaviour<List<T>, RuntimeSetReference<T>>, IList<T>, ListenerSubject<ListReferenceListener<T>> {

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

    public void Add(T item) {
        throw new System.NotImplementedException();
    }

    public void Clear() {
        throw new System.NotImplementedException();
    }

    public bool Contains(T item) {
        throw new System.NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex) {
        throw new System.NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator() {
        throw new System.NotImplementedException();
    }

    public int IndexOf(T item) {
        throw new System.NotImplementedException();
    }

    public void Insert(int index, T item) {
        throw new System.NotImplementedException();
    }

    public bool Remove(T item) {
        throw new System.NotImplementedException();
    }

    public void RemoveAt(int index) {
        throw new System.NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        throw new System.NotImplementedException();
    }

    public void addListener(ListReferenceListener<T> listener) {
        throw new System.NotImplementedException();
    }

    public void removeListener(ListReferenceListener<T> listener) {
        throw new System.NotImplementedException();
    }
}