using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingObject : MonoBehaviour {

    /// <summary>
    /// Singleton
    /// </summary>
    public static FlashingObject Instance;

    public SpriteRenderer sprite;

    bool isFlashing = false;

    public void makeSpriteFlashRed() {
        StartCoroutine(FlashSprite(sprite, .3f, .1f, redColors));
    }
    public void makeSpriteFlashBlue() {
        StartCoroutine(FlashSprite(sprite, .3f, .1f, blueColors));
    }




    private Color[] redColors = { Color.white, Color.red };
    private Color[] blueColors = { Color.white, Color.cyan, Color.blue };


    public void Awake() {
        // Register the singleton
        if (Instance != null) {
            Debug.LogError("Multiple instances of FlashingObject!");
        }
        Instance = this;
    }

    IEnumerator FlashSprite(SpriteRenderer sprite, float time, float intervalTime, Color[] colors) {
        isFlashing = true;
        float elapsedTime = 0f;
        int index = 0;
        while (elapsedTime < time) {
            sprite.color = colors[index % 2];

            elapsedTime += Time.deltaTime;
            index++;
            yield return new WaitForSeconds(intervalTime);
        }

        sprite.color = Color.white;
        isFlashing = false;

    }
    

}