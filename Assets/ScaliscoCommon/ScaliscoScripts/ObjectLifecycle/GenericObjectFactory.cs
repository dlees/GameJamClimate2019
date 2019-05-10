using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Makes a copy of a template and makes it active.
 * - Don't use prefabs, use an inactive object in the scene.
 * --- (If you want to use values from the scene)
 * */
public class GenericObjectFactory : MonoBehaviour {

    public GameObject template;

    public Transform parentOverride = null;

    public bool overrideTransform = false;
    public Vector3Reference positionOverride = null;
    public QuaternionReference rotationOverride = null;

    void Start() {
        if (parentOverride == null) {
            parentOverride = template.transform.parent;
        } 
    }

    public GameObject createAndGetObject() {
        Vector3 newPos = overrideTransform == false ? template.transform.position : positionOverride.Value;
        Quaternion newRotation = overrideTransform == false ? template.transform.rotation : rotationOverride.Value;

        GameObject newObject = GameObject.Instantiate(template, newPos, newRotation, parentOverride);

        newObject.SetActive(true);
        return newObject;
    }

    public void createObject() {
        createAndGetObject();
    }

    public void createObject(Anything anything) {
        createAndGetObject().GetComponent<Anything>().copyFrom(anything);
    }
}
