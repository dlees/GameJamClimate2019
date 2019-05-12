using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AnimateWater : MonoBehaviour
{
    public float speed=1;
    public Tilemap tileMap;
    Vector3 defaultAnchor = new Vector3(0.5f, 0.5f, 0f);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        tileMap.tileAnchor = tileMap.tileAnchor + new Vector3(-speed*Time.deltaTime, -speed*Time.deltaTime, 0);
        if (tileMap.tileAnchor.x < -0.5)
            tileMap.tileAnchor = defaultAnchor;
    }
}

