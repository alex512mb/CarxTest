using UnityEngine;

public class CannonTower : Tower
{
	[SerializeField] Rigidbody m_projectilePrefab;

    [SerializeField] float m_angularSpeed;

    const float m_reachAngle = 2;
    float signedAngle;
    Vector3 targetWithPreemptive;

    protected override void Awake()
    {
        base.Awake();
        if (m_projectilePrefab == null)
        {
            Debug.LogError("missing reference to the projectile in inspector of the tower: " + name);
            enabled = false;
        }

    }

    protected override void OnTargetDetected(Monster target, Vector3 shotPos)
    {
        float timeFlyProjectile = PhysicsMathf.GetTimeForLinearParabolicMove(shotPos, target.transform.position);
        Vector3 preemptiveVector = target.VelocityMove * timeFlyProjectile;
        targetWithPreemptive = target.transform.position + preemptiveVector;
        Vector3 direction2d_toTarget = new Vector3(targetWithPreemptive.x, transform.position.y, targetWithPreemptive.z) - transform.position;
        signedAngle = Vector3.SignedAngle(direction2d_toTarget, transform.forward, Vector3.up);
        float sign = signedAngle >= 0 ? 1 : -1;

        transform.Rotate(Vector3.up, -sign * m_angularSpeed * Time.deltaTime);
    }

    protected override bool TryShot(GameObject target, Vector3 shotPos)
    {
        if (signedAngle <= m_reachAngle && signedAngle >= -m_reachAngle)
        {
            Rigidbody body = Instantiate<Rigidbody>(m_projectilePrefab, shotPos, Quaternion.identity);

            float velosity = PhysicsMathf.GetVelocityForLinearParabolicMove(shotPos, targetWithPreemptive, body.mass);
            Vector3 force = transform.forward * velosity;

            body.AddForce(force);
            return true;
        }
        else
            return false;
    }

}
