using UnityEngine;

public class GuidedProjectile : Projectile
{
	[SerializeField] float m_speed = 0.2f;
	
	GameObject m_target;

    void Update ()
    {
		if (m_target == null) {
			Destroy (gameObject);
			return;
		}

		var translation = m_target.transform.position - transform.position;
		if (translation.magnitude > m_speed) {
			translation = translation.normalized * m_speed;
		}
		transform.Translate (translation);
	}
     
    public void SetTarget(GameObject target)
    {
        m_target = target;
    }
}
