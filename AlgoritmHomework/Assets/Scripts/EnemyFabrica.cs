using UnityEngine;

[RequireComponent(typeof(EnemySpawner))]
[RequireComponent(typeof(SaveService))]

public class EnemyFabrica : MonoBehaviour
{
    private SaveService _saveService;

    private void Awake()
    {
        _saveService = GetComponent<SaveService>();
    }
    public Enemy CreateEnemy(Vector3 position, EnemyColors color)
    {
        Enemy enemy = null;

        switch (color)
        {
            case EnemyColors.Black:
                enemy = Instantiate(Resources.Load<Enemy>("BlackEnemy"), position, Quaternion.identity)
                    .SetHealth(Random.Range(0, 100))
                    .SetType(color);
                enemy.Save(EnemyColors.Black);
                break;
            case EnemyColors.Blue:
                enemy = Instantiate(Resources.Load<Enemy>("BlueEnemy"), position, Quaternion.identity)
                    .SetHealth(Random.Range(0, 100))
                    .SetType(color);
                enemy.Save(EnemyColors.Blue);
                break;
            case EnemyColors.Green:
                enemy = Instantiate(Resources.Load<Enemy>("GreenEnemy"), position, Quaternion.identity)
                    .SetHealth(Random.Range(0, 100))
                    .SetType(color);
                enemy.Save(EnemyColors.Green);
                break;
            case EnemyColors.White:
                enemy = Instantiate(Resources.Load<Enemy>("WhiteEnemy"), position, Quaternion.identity)
                    .SetHealth(Random.Range(0, 100))
                    .SetType(color);
                enemy.Save(EnemyColors.White);
                break;
            case EnemyColors.Red:
                enemy = Instantiate(Resources.Load<Enemy>("RedEnemy"), position, Quaternion.identity)
                    .SetHealth(Random.Range(0, 100))
                    .SetType(color);
                enemy.Save(EnemyColors.Red);
                break;
            default:
                Debug.Log("Wrong color");
                break;
        }
        return enemy;
    }
}
