using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyFactory))]

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    private EnemyFactory _enemyFactory;
    private Coroutine _spawnTick;

    private void Awake()
    {
        _enemyFactory = GetComponent<EnemyFactory>();
    }

    private void Start()
    {
        StartCoroutine(SpawnTick());
    }

    private void CreateEnemy()
    {
        int random = Random.Range(0, 100);
        
        if (random <= 33)
            _enemyFactory.CreateEnemy();
        else if (random <= 66)
            _enemyFactory.CreateBigEnemy();
        else
            _enemyFactory.CreateFastEnemy();
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
