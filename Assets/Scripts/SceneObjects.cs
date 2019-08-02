using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class SceneObjects : MonoBehaviour
{
    static SceneObjects s_Instance;
    List<Monster> m_monsters;

    void Awake()
    {
        m_monsters = new List<Monster>();
        s_Instance = this;
    }

    public static void AddMonster(Monster monster)
    {
        s_Instance.m_monsters.Add(monster);
    }
    public static void RemoveMonster(Monster monster)
    {
        s_Instance.m_monsters.Remove(monster);
    }
    public static List<Monster> GetAllMonsters()
    {
        return s_Instance.m_monsters;
    }
	
}
