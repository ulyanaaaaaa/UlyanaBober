using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EntryPoint _entryPoint;
    
    private EnemyFabrica _enemyFabrica;
    private Coroutine _spawnTick;

    private void Awake()
    {
        _enemyFabrica = GetComponent<EnemyFabrica>();
        _spawnTick = StartCoroutine(SpawnTick());
    }

    private void Setup()
    {
        foreach (IEntryPointSetupEnemy setupEnemy in _entryPoint.SetupEnemies)
            setupEnemy.Setup(_entryPoint.EnemyCreated);
    }

    private void EnemyCreated(Transform position)
    {
        IEntryPointSetupEnemy enemyCreated = null;

        int random = Random.Range(0, 100);

        if (random < 20)
            _enemyFabrica.CreateRedEnemy(position.transform);
        if (random >= 20 && random < 40)
            _enemyFabrica.CreateGreenEnemy(position.transform);
        if (random >= 40 && random < 60)
            _enemyFabrica.CreateBlackEnemy(position.transform);
        if (random >= 60 && random < 80)
            _enemyFabrica.CreateBlueEnemy(position.transform);
        if (random >= 80)
            _enemyFabrica.CreateWhiteEnemy(position.transform);
    }

    private IEnumerator SpawnTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            
            foreach (Transform point in _entryPoint.EnemyStartPoints)
                EnemyCreated(point);
        }
    }
}
