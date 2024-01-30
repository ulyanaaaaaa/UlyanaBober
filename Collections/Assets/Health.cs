using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
            Delete();

        if (Input.GetKeyDown(KeyCode.F))
            RandomDelete();

    }

    private void Delete()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].Id % 2 != 0)
                RemoveEnemies(i);
        }
    }

    private void RandomDelete()
    {
        if (Random.Range(0, 10) >= 7)
            RemoveEnemies(Random.Range(0, _enemies.Count));
    }

    private void RemoveEnemies(int i)
    {
        _enemies[i].Die();
        _enemies.RemoveAt(i);
    }
}
