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
    public TransformListReference idlePath;

    public TransformListReferenceBehaviour pathReferenceBehaviour;

    void Start() {
        pathReferenceBehaviour.reference = idlePath;

        players = GameObject.FindGameObjectsWithTag("Player");
        switch (movementType) {
            case "stopped":
                movementSeeker.enabled = false;
                break; 

            case "away":
                movementSeeker.destinationTransform = players[0].transform;
                movementSeeker.shouldMoveAway = true;
                break;

            case "toward":
                movementSeeker.destinationTransform = players[0].transform;
                movementSeeker.shouldMoveAway = false;

                break;

            default: 
                movementSeeker.destinationTransform = players[0].transform;
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
