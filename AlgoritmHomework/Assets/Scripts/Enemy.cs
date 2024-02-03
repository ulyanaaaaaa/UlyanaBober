using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Enemies
{
    Red,
    Green,
    Black,
    Blue,
    White
}

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    private Enemies _type;
    private Transform _enemy;

    public List<Enemy> CreatedEnemy = new List<Enemy>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            ListSort(Enemies.Black);
        if (Input.GetKeyDown(KeyCode.S))
            ListSort(Enemies.Red);
        if (Input.GetKeyDown(KeyCode.E))
            ListSort(Enemies.Blue);
    }

    public Enemy SetHealth(int health)
    {
        _health = health;
        return this;
    }

    public Enemy SetType(Enemies type)
    {
        _type = type;
        return this;
    }
    
    private void ListSort(Enemies type)
    {
        var selectedEnemies = from enemy in CreatedEnemy
            where enemy._type == type
            select enemy;
        
        foreach (var enemy in selectedEnemies)
            Debug.Log(enemy);
    }
}
