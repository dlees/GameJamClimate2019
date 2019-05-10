using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringListViewController : MonoBehaviour {
    public StringSetReference strings;
    public GameObject contentPanel;
    public GameObject listItemTemplate;

    public void OnEnable() {
        reload();
    }

    public void reload() {

        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }

        createListItems();
    }

    public void createListItems() {

        foreach (string str in strings.Value) {
            GameObject assetView = Instantiate(listItemTemplate) as GameObject;
            assetView.GetComponent<StringReferenceBehaviour>().reference = new StringReference(str);

            assetView.transform.SetParent(contentPanel.transform);
            assetView.transform.localScale = Vector3.one;
        }
    }
}
