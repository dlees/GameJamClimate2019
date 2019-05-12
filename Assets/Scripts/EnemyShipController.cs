using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public string movementType;
    public int numWaterJets;

    public Seeker playerSeeker;
    public Seeker idleSeeker;
    public GameObject[] players;

    public GameObject[] turrets;
    public Defend2D[] defenders;

    public TransformListReference cameraObjects;
    public TransformListReferenceBehaviour cameraObjectsReference;

    public TransformListReference idlePath;

    public TransformListReferenceBehaviour pathReferenceBehaviour;

    void Start() {
        pathReferenceBehaviour.reference = idlePath;

        players = GameObject.FindGameObjectsWithTag("Player");
        switch (movementType) {
            case "stopped":
                idleSeeker.enabled = false;
                playerSeeker.enabled = false;
                break; 

            case "away":
                playerSeeker.destinationTransform = players[0].transform;
                playerSeeker.shouldMoveAway = true;
                break;

            case "toward":
                playerSeeker.destinationTransform = players[0].transform;
                playerSeeker.shouldMoveAway = false;

                break;

            default: 
                playerSeeker.destinationTransform = players[0].transform;
                playerSeeker.shouldMoveAway = true;
                break;
        }

        for (int i = 0; i < turrets.Length; i++) {
            turrets[i].SetActive(i < numWaterJets);
        }

        cameraObjectsReference.setReference(cameraObjects);

        foreach (Defend2D defender in defenders) {
            defender.target = players[0];
        }

        
    }
}
