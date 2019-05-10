using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererController : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public StringReference reference;

    void Update() {
        spriteRenderer.sprite = Resources.Load<Sprite>(reference);
    }
}
