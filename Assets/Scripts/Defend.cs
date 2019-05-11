using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : MonoBehaviour
{

    public GameObject target;
    public GameObject turret;
    //public GameObject projectile;
    public float minDistance = 1f;
    public float maxDistance = 10f;
    public float turnSpeed = 2;
    public float minAngleDiffToFire = 1;
    public float ProjectileFireVelocity = 10;


    // Start is called before the first frame update
    void Start()
    {
        turret.transform.localRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetWithinDistance())
        {
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

        float theta = 0.5f * Mathf.Asin(9.81f * DistanceToTarget() / Mathf.Pow(ProjectileFireVelocity, 2f));
        Debug.Log("I would have fired with this angle: " + theta);

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
        float relativeAngle = Vector3.Angle(turret.transform.forward, target.transform.position - turret.transform.position;
        Debug.Log("Turret: Relative Angle to Target: " + relativeAngle);
        return (relativeAngle < minAngleDiffToFire);
    }
}
