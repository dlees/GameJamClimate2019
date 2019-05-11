﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend2D : MonoBehaviour
{

    public GameObject target;
    public GameObject turret;
    public GameObject projectile;
    public float minDistance = 1f;
    public float maxDistance = 50f;
    public float turnSpeed = 0.1f;
    public float minAngleDiffToFire = 1f;
    public float ProjectileFireVelocity = 10f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (TargetWithinDistance())
        {
            Debug.Log("Turret: Target with distance");
            RotateTurretToTarget();
            Fire();
        }
    }

    void Fire()
    {   
        if (!FacingTarget())
        {
            return;
        }

        GameObject p = Instantiate(projectile, turret.transform.position, turret.transform.rotation);
        float scale = Mathf.Lerp(0f, turnSpeed, DistanceToTarget() / maxDistance);
        p.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * ProjectileFireVelocity * scale);
        Destroy(p, 1);
    }

    void RotateTurretToTarget()
    {
    
        turret.transform.rotation = getNewRotation(turnSpeed);
    }

    private Quaternion getNewRotation(float scale)
    {
        Quaternion q = Quaternion.AngleAxis(angleToTarget(), Vector3.forward);
        return Quaternion.Slerp(transform.rotation, q, scale);

    }

    float angleToTarget()
    {
        Vector3 vectorToTarget = target.transform.position - transform.position;
        return Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
    }

    bool TargetWithinDistance()
    {
        float distance = DistanceToTarget();
        return distance >= minDistance || distance <= maxDistance;

    }
    float DistanceToTarget()
    {
        return Vector2.Distance(target.transform.position, turret.transform.position); ;
    }

    bool FacingTarget()
    {
        float relativeAngle = Vector3.Angle(turret.transform.up, target.transform.position - turret.transform.position);
        Debug.Log("Turret: forward " +turret.transform.up);
        Debug.Log("Turret: Relative Angle to Target: " + relativeAngle);
        return (relativeAngle < minAngleDiffToFire);
    }
}