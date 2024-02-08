using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private EnemyFabrica _enemyFabrica;
    private Coroutine _spawnTick;

    private void Awake()
    {
        _enemyFabrica = GetComponent<EnemyFabrica>();
        _spawnTick = StartCoroutine(SpawnTick());
    }

    private void EnemyCreated(Vector3 position)
    {
        int random = Random.Range(0, 100);

        if (random < 20)
            _enemyFabrica.CreateRedEnemy(position);
        if (random >= 20 && random < 40)
            _enemyFabrica.CreateGreenEnemy(position);
        if (random >= 40 && random < 60)
            _enemyFabrica.CreateBlackEnemy(position);
        if (random >= 60 && random < 80)
            _enemyFabrica.CreateBlueEnemy(position);
        if (random >= 80)
            _enemyFabrica.CreateWhiteEnemy(position);
    }

    private IEnumerator SpawnTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(2); 
            EnemyCreated(new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f)));
        }
    }
}