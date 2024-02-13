using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;

    private void Die(Spawner spawner)
    {
        spawner.DeleteEnemy(this);
        Destroy(gameObject);
    }

    public void Hit(float damage, Spawner spawner)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die(spawner);
        }
    }
}
