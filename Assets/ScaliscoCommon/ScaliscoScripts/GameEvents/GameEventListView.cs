using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEventListView : GameEventListener {

    public GameObject ContentPanel;
    public GameObject listItemPrefab;

    public override void OnEventRaised(Anything eventAnything) {
        GameObject newObject = Instantiate(listItemPrefab) as GameObject;

        Anything objectAnything = newObject.GetComponent<Anything>() as Anything;
        if (eventAnything != null && objectAnything != null) {
            objectAnything.data = new Dictionary<string, object>(eventAnything.data);
        } 

        newObject.transform.SetParent(ContentPanel.transform);
        newObject.transform.localScale = Vector3.one;    }

}
