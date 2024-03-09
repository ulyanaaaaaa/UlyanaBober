using UnityEngine;

public class TowerBall : Ball
{
    private void Update()
    {
        _rigidbody.velocity = Vector3.right * _speed;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }
}
