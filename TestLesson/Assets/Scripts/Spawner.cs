using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Enemy> Enemies = new List<Enemy>();
    public Action OnDelete;
    
    private Coroutine _spawnTick;
    [SerializeField] private Player _player;
    [SerializeField] private float _delay;
    [SerializeField] private float _speed;

    private void Awake()
    {
        _spawnTick = StartCoroutine(SpawnTick());
    }

    private IEnumerator SpawnTick()
    {
        while (true)
        {
            Enemy enemy = Instantiate(Resources.Load<Enemy>("Enemy"), transform.position, Quaternion.identity);
            Enemies.Add(enemy);
            Debug.Log("Start");
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, _player.transform.position, _speed);
            Debug.Log("Finish");
            yield return new WaitForSeconds(_delay);
        }
    }

    public void DeleteEnemy(Enemy enemy)
    {
        Enemies.Remove(enemy);
    }
}
