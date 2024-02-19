using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Player _player;
    public IHit CreateEnemy()
    {
        Enemy enemy = Resources.Load<Enemy>("Enemy");
        enemy.Setup(_player);
        return Instantiate(enemy, _spawnPosition.position, Quaternion.identity);
    }
    
    public IHit CreateBigEnemy()
    {
        BigEnemy enemy = Resources.Load<BigEnemy>("Enemy");
        enemy.Setup(_player);
        return Instantiate(enemy, _spawnPosition.position, Quaternion.identity);
    }
    
    public IHit CreateFastEnemy()
    {
        FastEnemy enemy = Resources.Load<FastEnemy>("Enemy");
        enemy.Setup(_player);
        return Instantiate(enemy, _spawnPosition.position, Quaternion.identity);
    }
}
