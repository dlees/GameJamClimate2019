using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorFromString : MonoBehaviour {
    public Image image;
    public ColorMap colorMap;

    public void setColor(string colorString) {
        image.color = colorMap.getColor(colorString);
    }
    public void setColor(StringReferenceBehaviour colorString) {
        setColor(colorString.Value);
    }
}
