using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyFabrica))]

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _respawnTime;
    
    public Coroutine RespawnEnemyTick;


    [SerializeField] private EnemyFabrica _fabrica;
    [SerializeField] private EntryPoint _entryPoint;

    private void Awake()
    {
        _fabrica = GetComponent<EnemyFabrica>();
        RespawnEnemyTick = StartCoroutine(RespawnTick());
    }

    private void Setup()
    {
        foreach (IEntryPointSetupPlayer setupPlayer in _entryPoint.SetupsPlayer)
        {
            setupPlayer.Setup(_entryPoint.PlayerCreated);
        }
    }

    private void EnemyCreated(Transform position)
    {
        IEntryPointSetupPlayer enemyCreated = null;
        
        int random = Random.Range(0, 100);

        if (random < 50)
        {
            _fabrica.CreateBasic(position.transform);
        }

        if (random < 75 && random >= 50)
        {
            _fabrica.CreateGhost(position.transform);
        }

        if (random >= 75)
        {
            _fabrica.CreateDemon(position.transform);
        }
    }

    private IEnumerator RespawnTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(_respawnTime);
            
            foreach (Transform point in _entryPoint.EnemyStartPoints)
            {
                EnemyCreated(point);
            }

            Setup();
        }
    }
    
}
