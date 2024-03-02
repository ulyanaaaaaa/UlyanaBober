using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerBomb : MonoBehaviour
{
    [SerializeField] private float _force;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _rigidbody.velocity = Vector2.up * _force;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _animator.SetTrigger("Explosion");
            enemy.Die();
        }
    }
}
