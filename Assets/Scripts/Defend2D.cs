using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend2D : MonoBehaviour
{

    public GameObject target;
    public GameObject turret;
    public GameObject projectile;
    public AudioSource waterStream;
    public float minDistance = 0.75f;
    public float maxDistance = 9f;
    public float turnSpeed = 7f;
    public float minAngleDiffToFire = 3f;
    public float projectileFireVelocity = 100f;
    public float timeBetweenProjectiles = 0.05f;
    public float timeFromLastFire = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (TargetWithinDistance())
        {
            RotateTurretToTarget();
            Fire();
            
        }
        else if (waterStream.isPlaying && timeFromLastFire > 4)
            waterStream.Stop();
    }

    void Fire()
    {
        timeFromLastFire += Time.deltaTime;
        if (!FacingTarget() || timeFromLastFire < timeBetweenProjectiles)
        {
            return;
        }
        if (!waterStream.isPlaying)
            waterStream.Play();

        GameObject p = Instantiate(projectile, turret.transform.position, turret.transform.rotation);
        float scale = Mathf.Lerp(0f, 1, DistanceToTarget() / maxDistance);
        Rigidbody2D rb = p.GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector2.up * projectileFireVelocity);
        rb.velocity = turret.GetComponentInParent<Rigidbody2D>().velocity;

        Destroy(p, 4* scale);
        timeFromLastFire = 0f;
    }

    void RotateTurretToTarget()
    {
    
        turret.transform.rotation = getNewRotation(turnSpeed);
    }

    private Quaternion getNewRotation(float scale)
    {
        Quaternion q = Quaternion.AngleAxis(angleToTarget(), Vector3.forward);
        return Quaternion.Slerp(turret.transform.rotation, q, Mathf.Clamp01(scale*Time.deltaTime));

    }

    float angleToTarget()
    {
        Vector3 vectorToTarget = target.transform.position - transform.position;
        return Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
    }

    bool TargetWithinDistance()
    {
        float distance = DistanceToTarget();
        return distance >= minDistance && distance <= maxDistance;

    }
    float DistanceToTarget()
    {
        return Vector2.Distance(target.transform.position, turret.transform.position); ;
    }

    bool FacingTarget()
    {
        float relativeAngle = Vector3.Angle(turret.transform.up, target.transform.position - turret.transform.position);
        return relativeAngle < minAngleDiffToFire;
    }
}
