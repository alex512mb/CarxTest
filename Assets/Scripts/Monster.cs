using UnityEngine;

public class Monster : MonoBehaviour {

	[SerializeField] float m_speed = 0.1f;
	[SerializeField] int m_maxHP = 30;

    public Vector3 VelocityMove
    {
        get
        {
            Vector3 direction = m_destination - transform.position;
            return direction.normalized * m_speed;
        }
    }

	int m_hp;
    Vector3 m_destination;

	const float m_reachDistance = 0.3f;

    void Awake()
    {
        SceneObjects.AddMonster(this);
    }
    void OnDestroy()
    {
        SceneObjects.RemoveMonster(this);
    }
    void Start()
    {
		m_hp = m_maxHP;
	}
	void Update ()
    {
		if (Vector3.Distance (transform.position, m_destination) <= m_reachDistance) {
			Destroy (gameObject);
			return;
		}
		
		transform.Translate (VelocityMove * Time.deltaTime);
	}

    public void ApplyDamage(int damage)
    {
        m_hp -= damage;
        if (m_hp <= 0)
            Destroy(gameObject);
    }
    public void SetDestination(Vector3 pos)
    {
        m_destination = pos;
    }
}
