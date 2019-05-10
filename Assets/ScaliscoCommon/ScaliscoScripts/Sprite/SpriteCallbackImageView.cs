using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SpriteCallback : SerializableCallback<Sprite> { }

public class SpriteCallbackImageView : MonoBehaviour {

    public Image image;
    public SpriteCallback sprite;

    void OnEnable() {
        image.sprite = sprite.Invoke();
    }
}
