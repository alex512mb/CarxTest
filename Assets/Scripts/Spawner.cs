using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Monster m_prefabMonster;
	[SerializeField] float m_interval = 3;
	[SerializeField] Transform m_moveTarget;

	float m_lastSpawn = -1;

	void Update ()
    {
		if (Time.time > m_lastSpawn + m_interval)
        {
            SpawnMonster();
            m_lastSpawn = Time.time;
        }
    }

    void SpawnMonster()
    {
        Monster newMonster = Instantiate(m_prefabMonster, transform.position, Quaternion.identity);
        newMonster.SetDestination(m_moveTarget.position);
    }
}
