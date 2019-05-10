using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface Copiable {
    void copyFrom(MonoBehaviour behaviourTemplate);
}

public class IncrementNotificationFactory : MonoBehaviour , Copiable {

	public GameObject fadingPopupPrefab;
	public GameObject[] position;
	public GameObject destination;
	public Canvas canvas;
	public GameObject parent;
    public string formatString = "{0}";
    public Anything anythingContainingIncrement = null;


    public IncrementNotificationFactory factoryToCopy;

	// Use this for initialization
	void Start () { 
		if (parent == null) {
			parent = this.gameObject;
		}
	}

	// From random starting position
    public void createIncrementNotification(float value) {
		Vector3 pos = position [UnityEngine.Random.Range (0, position.Length)].transform.position;
		createIncrementNotification(value, new Vector2(pos.x, pos.y));
    }

    // From value in Anything object
    public void createIncrementNotification(string floatKeyInAnything) {
        if (anythingContainingIncrement == null) {
            anythingContainingIncrement = (GetComponent<Anything>() as Anything);
        }

        if (!anythingContainingIncrement.data.ContainsKey(floatKeyInAnything)) {
            throw new KeyNotFoundException(floatKeyInAnything + " isn't in dictionary. Contents: " + ContainerConverter.keysToString(anythingContainingIncrement.data));
        }
        float value = (anythingContainingIncrement.data[floatKeyInAnything] as FloatReference).Value;
        createIncrementNotification(value);
    }

    public void createIncrementNotification(float value, Vector2 pos) {
        GameObject newObject = GameObject.Instantiate(fadingPopupPrefab);
        newObject.transform.position = new Vector3(pos.x, pos.y, 0.0f) ;

		newObject.transform.SetParent(parent.transform);
        newObject.transform.localScale = fadingPopupPrefab.transform.localScale;

        if (!formatString.Equals("")) {
            newObject.GetComponent<IncrementNotification>().incrementText.text = NumberConverter.getString(value, formatString);
        }
        if (destination != null) {
            Seeker seeker = (Seeker)newObject.GetComponent<Seeker>();
            if (seeker != null) {
                seeker.changeDestination(destination);
            }
        }

        FloatReferenceBehaviour newObjectFloatRef = (FloatReferenceBehaviour)newObject.GetComponent<FloatReferenceBehaviour>();
        if (newObjectFloatRef != null) {
            newObjectFloatRef.Value = value;
        }

        IncrementNotificationFactory factory = (IncrementNotificationFactory)newObject.GetComponent<IncrementNotificationFactory>();
        if (factory != null) {
            if (factoryToCopy != null) {
                factory.copyFrom(factoryToCopy);
            } else {
                factory.canvas = canvas;
                factory.position = new GameObject[] { destination };
                factory.parent = parent;
            }
        }
    }

    public void copyFrom(MonoBehaviour behaviourTemplate) {
        IncrementNotificationFactory factoryTemplate = (IncrementNotificationFactory)behaviourTemplate;
        this.destination = factoryTemplate.destination;
        this.canvas = factoryTemplate.canvas;
        this.parent = factoryTemplate.parent;
        this.position = factoryTemplate.position;
    }
}
