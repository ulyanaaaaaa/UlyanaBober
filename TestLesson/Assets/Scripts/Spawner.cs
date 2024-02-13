using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Enemy> Enemies = new List<Enemy>();
    
    private Coroutine _spawnTick;
    [SerializeField] private Enemy _enemy;
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
            Enemy enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
            Enemies.Add(enemy);
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, _player.transform.position, _speed);
            yield return new WaitForSeconds(_delay);
        }
    }
}
