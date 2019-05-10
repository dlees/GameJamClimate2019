using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteNameStringReferenceInitializer : MonoBehaviour {

    public Image image;
    public StringReference stringRef;

	void Update () {
        if (image.sprite == null) {
            stringRef.setValue("");
        } else { 
            stringRef.setValue("Sprites/Costumes/" + image.sprite.name);
        }
    }
}
