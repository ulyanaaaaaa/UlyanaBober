using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Player _player;
    public Enemy CreateEnemy()
    {
        Enemy enemy = Resources.Load<Enemy>("Enemy");
        enemy.Setup(_player);
        return Instantiate(enemy, _spawnPosition.position, Quaternion.identity);
    }
    
    public Enemy CreateBigEnemy()
    {
        Enemy enemy = Resources.Load<BigEnemy>("BigEnemy");
        enemy.Setup(_player);
        return Instantiate(enemy, _spawnPosition.position, Quaternion.identity);
    }
    
    public Enemy CreateFastEnemy()
    {
        Enemy enemy = Resources.Load<FastEnemy>("FastEnemy");
        enemy.Setup(_player);
        return Instantiate(enemy, _spawnPosition.position, Quaternion.identity);
    }
}
