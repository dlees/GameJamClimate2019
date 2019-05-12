using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public string movementType;
    public int numWaterJets;

    public Seeker movementSeeker;
    public GameObject[] players;

    public GameObject[] turrets;
    public Defend2D[] defenders;

    public TransformListReference cameraObjects;

    void Start() {
        players = GameObject.FindGameObjectsWithTag("Player");
        switch (movementType) {
            case "stopped":
                movementSeeker.enabled = false;
                break; 

            case "away":
                movementSeeker.destination = players[0];
                movementSeeker.shouldMoveAway = true;
                break;

            case "toward":
                movementSeeker.destination = players[0];
                movementSeeker.shouldMoveAway = false;

                break;

            default: 
                movementSeeker.destination = players[0];
                movementSeeker.shouldMoveAway = true;
                break;
        }

        for (int i = 0; i < turrets.Length; i++) {
            turrets[i].SetActive(i < numWaterJets);
        }

        foreach (Defend2D defender in defenders) {
            defender.target = players[0];
        }

        
    }
}
