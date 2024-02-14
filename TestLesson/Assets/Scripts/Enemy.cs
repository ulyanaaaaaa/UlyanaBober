using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;
    private Player _player;
    private Spawner _spawner;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Setup(Player player, Spawner spawner)
    {
        _player = player;
        _spawner = spawner;
    }

    private void Update()
    {
        _rigidbody.velocity = (_player.transform.position - transform.position).normalized * _speed;
    }

    private void Die()
    {
        _spawner.DeleteEnemy(this);
        Destroy(gameObject);
    }

    public void Hit(float damage)
    {
        _health -= damage;
        
        if (_health <= 0)
            Die();
    }
}
