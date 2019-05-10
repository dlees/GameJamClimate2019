using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anything : MonoBehaviour {
    public Dictionary<string, System.Object> data = new Dictionary<string, System.Object>();

    public void copyFrom(Anything anythingToCopy) {
        data = new Dictionary<string, System.Object>(anythingToCopy.data); 
    }

    public void loadFromGameObject(GameObject gameObject) {
        foreach (Component component in gameObject.GetComponents<MonoBehaviour>()) {
            data[component.GetType().Name] = component;
        }
    }

    public void unloadToGameObject(GameObject gameObject) {
        foreach (MonoBehaviour component in gameObject.GetComponents<MonoBehaviour>()) {
            CopyComponent(component, (Component)data[component.GetType().Name]);
        }
    }
    
    private void CopyComponent(Component copy, Component original) {
        System.Type type = original.GetType();

        // Copied fields can be restricted with BindingFlags
        // TODO: Replace this with only copying Components that implement a certain interface!!!
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields) {
            field.SetValue(copy, field.GetValue(original));
        }
    }
}
