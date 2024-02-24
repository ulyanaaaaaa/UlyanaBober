using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    private EnemyFabrica _enemyFabrica;
    private Coroutine _spawnTick;

    private void Awake()
    {
        _enemyFabrica = GetComponent<EnemyFabrica>();
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
