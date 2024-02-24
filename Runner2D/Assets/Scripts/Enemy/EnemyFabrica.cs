using UnityEngine;

public class EnemyFabrica : MonoBehaviour
{
    public Enemy CreateEnemy()
    {
        Enemy enemy = Resources.Load<Enemy>("Enemy");
        Vector2 randomPosition = new Vector2(8.35f, Random.Range(-3.5f, 3.5f));
        return Instantiate(enemy, randomPosition, Quaternion.identity);
    }
}
