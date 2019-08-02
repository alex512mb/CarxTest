using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] Transform m_shootPoint;

    [SerializeField] float m_shootInterval = 0.5f;
    [SerializeField] float m_range = 4f;

    float m_lastShotTime = -0.5f;


    protected virtual void Awake()
    {
        if (m_shootPoint == null)
        {
            Debug.LogError("missing reference to the m_shootPoint in inspector of the tower: " + name);
            enabled = false;
        }
    }
    protected virtual void Update()
    {
        if (Time.time > m_lastShotTime + m_shootInterval)
        {
            List<Monster> monstersInScene = SceneObjects.GetAllMonsters();
            for (int i = 0; i < monstersInScene.Count; i++)
            {
                //cheak distance
                if (Vector3.Distance(transform.position, monstersInScene[i].transform.position) < m_range)
                {
                    OnTargetDetected(monstersInScene[i],m_shootPoint.position);

                    if (TryShot(monstersInScene[i].gameObject, m_shootPoint.position))
                    {
                        m_lastShotTime = Time.time;
                        break;
                    }
                }
            }
        }
    }
    protected virtual void OnTargetDetected(Monster target, Vector3 shotPos)
    {

    }
    protected abstract bool TryShot(GameObject target, Vector3 shotPos);
}
