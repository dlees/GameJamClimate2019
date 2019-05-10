using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectEnabler : MonoBehaviour {

    public List<Condition> conditions;
    public List<GameObject> gameobjects;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < conditions.Count; i++) {
            gameobjects[i].SetActive(conditions[i].isConditionSatisfied());
        }
	}
}
