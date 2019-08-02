using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int m_damage = 10;

    void OnTriggerEnter(Collider other)
    {
        var monster = other.gameObject.GetComponent<Monster>();
        if (monster == null)
            return;

        monster.ApplyDamage(m_damage);
        Destroy(gameObject);
    }
}
