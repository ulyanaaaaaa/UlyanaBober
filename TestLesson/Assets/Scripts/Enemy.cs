using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Movement(Player player)
    {
        Debug.Log("Move");
        
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, _speed);
        Vector3 direction = (player.transform.position - transform.position).normalized;
        _rigidbody.velocity = direction * _speed;
    }

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
