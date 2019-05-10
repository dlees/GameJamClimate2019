using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

public class MassFontChanger : MonoBehaviour {

    [MenuItem("Scalisco/Change All Fonts")]
    public static void changeAllFonts() { 
        Text[] textComponents = Component.FindObjectsOfType<Text>() as Text[];
        foreach (Text component in textComponents) { 
            Font font = AssetDatabase.LoadAssetAtPath<Font>("Assets/Resources/MyArial.ttf");
            component.font = font;
        }
    }
}
