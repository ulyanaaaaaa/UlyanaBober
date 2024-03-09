using UnityEngine;

public class EnemyFabrica : MonoBehaviour
{
    public Enemy CreateEnemy(Vector3 position)
    {
        Enemy enemy = Resources.Load<Enemy>("Enemy");
        return Instantiate(enemy, position, Quaternion.identity);
    }
}
