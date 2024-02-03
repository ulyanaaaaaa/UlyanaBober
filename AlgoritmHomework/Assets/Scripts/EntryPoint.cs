using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] public List<Transform> EnemyStartPoints;
    [SerializeField] private EnemySpawner _spawner;

    public List<IEntryPointSetupEnemy> SetupEnemies = new List<IEntryPointSetupEnemy>();

    public Enemy EnemyCreated;
}

public interface IEntryPointSetupEnemy
{
    public void Setup(Enemy enemy);
}
