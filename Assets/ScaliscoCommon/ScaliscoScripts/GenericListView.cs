using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Uses Template Method Pattern to popualate a list view.
 * */
public abstract class AbstractListView<T> : MonoBehaviour, ListReferenceListener<T> {
    public GameObject contentPanel;
    public GameObject listItemPrefab;

    protected IList<T> list;

    [SerializeField]
    protected bool destroyOnStart;

    void Start() {
        if (destroyOnStart) {
            foreach (Transform child in transform) {
                Destroy(child.gameObject);
            }
        }

        list = getItems();
        listenToListChanges();
        populateItemViews();
    }


    public void populateItemViews() {
        for (int i = 0; i < list.Count; i++) {
            T item = list[i];
            createItemView(item, i);
        }
    }

    private void createItemView(T item, int index) {
        GameObject itemView = createItemView();
        installCustomItemViewProperties(itemView, item);
        setTransformForItemView(itemView, index);
    }

    protected abstract IList<T> getItems();

    protected abstract void installCustomItemViewProperties(GameObject itemView, T item);

    private GameObject createItemView() {
        return Instantiate(listItemPrefab) as GameObject;
    }

    private void setTransformForItemView(GameObject itemView, int index) {
        itemView.transform.SetParent(contentPanel.transform);
        itemView.transform.localScale = Vector3.one;
        itemView.transform.SetSiblingIndex(index);
    }

    private void listenToListChanges() {
        ListenerSubject<ListReferenceListener<T>> listenerSubject = list as ListenerSubject<ListReferenceListener<T>>;
        if (listenerSubject != null) {
            listenerSubject.addListener(this);
        }
    }

    public void OnItemAdded(T item, int index) {
        createItemView(item, index);
    }

    // WARN: Assumes the child is in the proper index
    public void OnItemRemoved(T item, int index) {
        Destroy(transform.GetChild(index));
    }

    public void OnAllItemsRefreshed() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        list = getItems();
        populateItemViews();
    }
}

// See AssetQuantityListView to see how it gets used
public class GenericListView<T, T_LIST_REFERENCE, T_REFERENCE_BEHAVIOUR> : AbstractListView<T>
    where T_LIST_REFERENCE : Valueable<List<T>>, IList<T>
    where T_REFERENCE_BEHAVIOUR : Valueable<T> {
    public T_LIST_REFERENCE items;

    protected override IList<T> getItems() {
        return items;
    }

    protected override void installCustomItemViewProperties(GameObject itemView, T item) {
        itemView.GetComponent<T_REFERENCE_BEHAVIOUR>().Value = item;
    }

}
