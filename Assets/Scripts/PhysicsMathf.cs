using UnityEngine;

public static class PhysicsMathf
{
    const float g = 9.8f;
    const float coeff_unity_physics = 50.2321f;
    /// <summary>
    /// Return velosity for shot to target under the gun
    /// </summary>
    /// <param name="PointA">point from will shot</param>
    /// <param name="PointB">point target will shot</param>
    /// <param name="massProjectile">mass of rigid body of the projectile</param>
    /// <returns></returns>
    public static float GetVelocityForLinearParabolicMove(Vector3 PointA, Vector3 PointB, float massProjectile)
    {
        float h = PointA.y - PointB.y;
        float d = (new Vector2(PointB.x, PointB.z) - new Vector2(PointA.x, PointA.z)).magnitude;
        float t = Mathf.Sqrt((2 * h) / g);
        float v = d / t;
        return v * coeff_unity_physics * massProjectile;
    }
    /// <summary>
    /// Return time fly projectile for shot to target under the gun
    /// </summary>
    /// <param name="PointA">point from will shot</param>
    /// <param name="PointB">point target will shot</param>
    /// <returns></returns>
    public static float GetTimeForLinearParabolicMove(Vector3 PointA, Vector3 PointB)
    {
        float h = PointA.y - PointB.y;
        float d = (new Vector2(PointB.x, PointB.z) - new Vector2(PointA.x, PointA.z)).magnitude;
        float t = Mathf.Sqrt((2 * h) / g);
        return t;
    }
}
