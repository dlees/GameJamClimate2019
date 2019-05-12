using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingObject : MonoBehaviour {

    /// <summary>
    /// Singleton
    /// </summary>
    public static FlashingObject Instance;

    public SpriteRenderer sprite;

    public void makeSpriteFlashRed() {
        chosenColors = redColors;
        StartCoroutine(FlashRed());
        Invoke("changeColorToBlue", .6f);
    }

    public void changeColorToBlue() {
        chosenColors = blueColors;
    }

    public void makeSpriteFlashBlue() {
        StartCoroutine(FlashBlue());
    }

    private Color[] redColors = { Color.white, Color.red };
    private Color[] blueColors = { Color.white, Color.cyan, Color.blue };
    private Color[] chosenColors;

    public void Awake() {
        // Register the singleton
        if (Instance != null) {
            Debug.LogError("Multiple instances of FlashingObject!");
        }
        Instance = this;

        chosenColors = blueColors;
}

    IEnumerator FlashRed() {
        IEnumerator enumerator =  FlashSprite(sprite, .3f, .1f);
        return enumerator;

    }
    IEnumerator FlashBlue() {
        return FlashSprite(sprite, .3f, .1f);
    }


    IEnumerator FlashSprite(SpriteRenderer sprite, float time, float intervalTime) {
        float elapsedTime = 0f;
        int index = 0;
        while (elapsedTime < time) {
            sprite.color = chosenColors[index % 2];

            elapsedTime += Time.deltaTime;
            index++;
            yield return new WaitForSeconds(intervalTime);
        }

        sprite.color = Color.white;

    }


}