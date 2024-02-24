using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _force;
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;
    
    [field: SerializeField] public float Damage { get; private set; }

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);

        if (_health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            TakeDamage(ball.Damage);
        }
    }

    private void TakeDamage(float damage)
    {
        _health -= damage;
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }
}
