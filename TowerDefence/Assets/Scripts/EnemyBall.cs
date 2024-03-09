using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBall : Ball
{
    private void Update()
    {
        _rigidbody.velocity = Vector3.left * _speed;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Tower tower))
        {
            tower.TakeDamage(_damage);
        }
    }
}
