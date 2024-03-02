using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyFactory))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    private EnemyFactory _enemyFabrica;
    private Coroutine _spawnTick;

    private void Awake()
    {
        _enemyFabrica = GetComponent<EnemyFactory>();
    }

    private void Start()
    {
        _spawnTick = StartCoroutine(SpawnTick());
    }

    private void CreateEnemy()
    {
        _enemyFabrica.CreateEnemy();
    }

    private IEnumerator SpawnTick()
    {
        while (true)
        {
            CreateEnemy();
            yield return new WaitForSeconds(_delay);
        }
    }
}