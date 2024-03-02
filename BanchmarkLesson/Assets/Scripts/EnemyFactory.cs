using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public Enemy CreateEnemy()
    {
        Enemy enemy = Resources.Load<Enemy>("Enemy");
        Vector2 randomPosition = new Vector2(Random.Range(-6.78f, 6.78f), 7f);
        return Instantiate(enemy, randomPosition, Quaternion.identity);
    }
}
