using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlphaChanger : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public float startAlpha = 1;
    public float endAlpha = 0;
    public float seconds = 1;

    private float curTime = 0;

    public bool pingPong = false;

    void Update()
    {
        curTime += Time.deltaTime;
        float newAlpha;
        if (!pingPong) {
            newAlpha = Mathf.Lerp(startAlpha, endAlpha, curTime / seconds);
        } else {
            newAlpha = Mathf.PingPong(curTime / seconds, endAlpha - startAlpha) + startAlpha;
        }

        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);
    }
}
