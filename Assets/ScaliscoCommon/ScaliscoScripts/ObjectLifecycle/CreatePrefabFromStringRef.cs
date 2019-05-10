using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefabFromStringRef : MonoBehaviour {

    public StringReference reference;

    public GenericObjectFactory factory;
    private string previousObjectName = "";
    private GameObject previousObject = null;

    void Update() {
        if (previousObjectName.Equals(reference.Value)) {
            return;
        }

        previousObjectName = reference.Value;

        Destroy(previousObject);

        factory.template = Resources.Load<GameObject>(reference);
        if (factory.template != null) {
            previousObject = factory.createAndGetObject();

        }
    }
}
