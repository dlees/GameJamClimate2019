using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasColliderSizer : MonoBehaviour {

    private int EXPECTED_SCREEN_HEIGHT = 600;

    public Rigidbody2D rigidBody;

    void Start () {
        float heightRatio = Screen.height / EXPECTED_SCREEN_HEIGHT;

        rigidBody.gravityScale *= heightRatio/2;

        float scaleFactor = 1.5f;// Screen.height / 1200 ; 
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(
        gameObject.GetComponent<BoxCollider2D>().size.x * scaleFactor,
        gameObject.GetComponent<BoxCollider2D>().size.y * scaleFactor 
        );
    }
}
