using UnityEngine;

public class SimpleTower : Tower
{
	[SerializeField] GuidedProjectile m_projectilePrefab;

    protected override void Awake()
    {
        base.Awake();
        if (m_projectilePrefab == null)
        {
            Debug.LogError("missing reference to the projectile in inspector of the tower: " + name);
            enabled = false;
        }
    }
    

    protected override bool TryShot(GameObject target, Vector3 shotPos)
    {
        GuidedProjectile projectile = Instantiate(m_projectilePrefab, shotPos, Quaternion.identity) as GuidedProjectile;
        projectile.SetTarget(target);
        return true;
    }
}
