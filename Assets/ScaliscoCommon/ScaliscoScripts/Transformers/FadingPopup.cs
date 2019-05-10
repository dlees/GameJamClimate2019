using UnityEngine;
using System.Collections;

public class FadingPopup : MonoBehaviour {
    
    public float destroyTime = 5.0f;
    public float floating_speed = 10.0f;

    void Start() {
        Destroy(gameObject, destroyTime);

    }

	void Update () {
        var y = Time.deltaTime * floating_speed;
        transform.Translate(0, y, 0);
	}
}
