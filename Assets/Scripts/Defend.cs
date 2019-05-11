using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : MonoBehaviour
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

        float theta = 0.5f * Mathf.Asin(9.81f * DistanceToTarget() / Mathf.Pow(ProjectileFireVelocity, 2f)) * Mathf.Rad2Deg;
        Debug.Log("Turret: I would have fired with this angle: " + theta);
        GameObject p = Instantiate(projectile, turret.transform.position, turret.transform.rotation);
        p.transform.Rotate(new Vector3(theta, 0f,0f));
        p.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * ProjectileFireVelocity);

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
