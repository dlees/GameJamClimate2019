using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMap : ScriptableObject {

    public List<string> strings;
    public List<Color> colors;
     
    private Dictionary<string, Color> colorMap = new Dictionary<string, Color>();

    void OnValidate() {
        for (int i = 0; i < strings.Count; i++) {
            colorMap[strings[i]] = colors[i];
        }
    }

    public Color getColor(string colorString) {
        try {

            return colors[strings.IndexOf(colorString)];

        } catch (KeyNotFoundException e) {
            Debug.LogError("'" + colorString + "' is not a valid string in " + name);
            throw e;
        }
    }
}
