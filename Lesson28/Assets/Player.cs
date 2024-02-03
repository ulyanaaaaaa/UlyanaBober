using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    private void Awake()
    {
        var selectedRedEnemies = from enemy in _enemies
            where enemy.Color == Color.red
            select enemy;
        
        var selectedGreenEnemies = from enemy in _enemies
            where enemy.Color == Color.green
            select enemy;
        
        var selectedEnemies = from enemy in selectedGreenEnemies
            where enemy.Health > 20 
            select enemy;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (i % 2 != 0)
                {
                    _enemies[i].TakeDamage(Random.Range(0f,100f));
                }
                else
                {
                    _enemies[i].TakeDamage(Random.Range(0f,100f) * 2);
                }
            }
        }
    }
}
