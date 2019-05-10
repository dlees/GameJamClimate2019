using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangedFloatImageView : MonoBehaviour {

    public RangedFloatReference rangedFloat;
    public GameObject contentPanel;
    public GameObject imagePrefab;

    // We're using the word obtained to mean:
    // the images 1-current in RangedFloat.
    public Sprite obtainedSprite;
    public Sprite unobtainedSprite;
    
    private List<Image> images = new List<Image>();

    void Start() {
        recreateChildren();
    }

    private void recreateChildren() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        images.Clear();

        for (int i = 0; i < rangedFloat.Max; i++) {
            GameObject imageObject = Instantiate(imagePrefab) as GameObject;

            imageObject.transform.SetParent(contentPanel.transform);
            imageObject.transform.localScale = Vector3.one;
            images.Add(imageObject.GetComponent<Image>());
        }
    }

    void Update () {
        if (rangedFloat.Max != images.Count) {
            recreateChildren();
        }

        for (int i = 0; i < images.Count; i++) {
            if (rangedFloat.Value < i + 1) {
                images[i].sprite = unobtainedSprite;
            } else {
                images[i].sprite = obtainedSprite;
            }
        }
	}
}
