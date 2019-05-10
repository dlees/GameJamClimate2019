using System.Collections;
using System.Collections.Generic;

public interface ListenerSubject<LISTENER> {
    void addListener(LISTENER listener);

    void removeListener(LISTENER listener);
}

public interface ListReferenceListener<T> {
    void OnItemAdded(T item, int index);

    void OnItemRemoved(T item, int index);

    void OnAllItemsRefreshed();
}

/// <summary>
/// Use this to have manage observers of a list of data. 
/// Use the methods update your lists while also updating the Listeners.
/// </summary>
public class ListListenerSubject<T> : ListenerSubject<ListReferenceListener<T>> {
    private List<ListReferenceListener<T>> listeners = new List<ListReferenceListener<T>>();

    public void addListener(ListReferenceListener<T> listener) {
        listeners.Add(listener);
    }

    public void removeListener(ListReferenceListener<T> listener) {
        listeners.Remove(listener);
    }

    public void Add(IList<T> items, T thing) {
        if (!items.Contains(thing)) {
            items.Add(thing);
            updateListenersOnInsert(thing, items.Count - 1);
        }
    }

    public void Clear(IList<T> items) {
        items.Clear();
        updateListenersOnAllItemsRefreshed();
    }

    public void Insert(IList<T> items, int index, T item) {
        items.Insert(index, item);
        updateListenersOnInsert(item, index);
    }

    public void RemoveAt(IList<T> items, int index) {
        T removedItem = items[index];
        items.RemoveAt(index);
        updateListenersOnRemove(removedItem, index);
    }

    public void Remove(IList<T> items, T thing) {
        RemoveAndReport(items, thing);
    }

    public bool RemoveAndReport(IList<T> items, T item) {
        int index = items.IndexOf(item);
        if (index >= 0) {
            items.Remove(item);
            updateListenersOnRemove(item, index);
            return true;
        }
        return false;
    }

    private void updateListenersOnInsert(T thing, int index) {
        listeners.ForEach(listener => listener.OnItemAdded(thing, index));
    }

    private void updateListenersOnRemove(T thing, int index) {
        listeners.ForEach(listener => listener.OnItemRemoved(thing, index));
    }

    private void updateListenersOnAllItemsRefreshed() {
        listeners.ForEach(listener => listener.OnAllItemsRefreshed());
    }
}
