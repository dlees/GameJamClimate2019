using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnythingToGameObjectLoader : MonoBehaviour
{
    public Anything anything;
    public GameObject objectToPopulate;
    public GameObject objectToEnableAfter;

    void Start()
    {
        anything.unloadToGameObject(objectToPopulate);

        if (objectToEnableAfter != null) {
            objectToEnableAfter.SetActive(false);
            objectToEnableAfter.SetActive(true);
        }

    }

}
