using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBomb : MonoBehaviour
{
    [SerializeField] private float _force;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody.velocity = Vector2.down * _force;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.Die();
        }
        
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            Destroy(gameObject);
        }
    }
}
