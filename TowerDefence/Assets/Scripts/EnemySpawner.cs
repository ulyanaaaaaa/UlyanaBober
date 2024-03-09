using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyFabrica))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    private Coroutine _spawnTick;
    private EnemyFabrica _enemyFabrica;

    private void Awake()
    {
        _enemyFabrica = GetComponent<EnemyFabrica>();
    }

    private void Start()
    {
        _spawnTick = StartCoroutine(SpawnTick());
    }

    private IEnumerator SpawnTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            Vector3 position = new Vector3(16f, 0.6f, Random.Range(-20, -5));
            _enemyFabrica.CreateEnemy(position);
        }
    }
}
