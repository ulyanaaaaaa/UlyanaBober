using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private BarriersFabrica _barriers;
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private int _invisibleTime = 3;
    [SerializeField] private float _jumpForce;
    private int _health;
    private Rigidbody2D _rigidbody;
    private bool _isInvisible;
    private bool _isGround;
    private Coroutine _invisibleTick;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            
        }
    }
    
    private void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Barrier barrier))
        {
            Hitten(barrier);
        }

        _isGround = collision.gameObject.TryGetComponent(out Ground ground) ? true : false;
    }

    private void Hitten(Barrier barrier)
    {
        if (!_isInvisible)
        {
            barrier.TakeDamage(_health);
            if (_health == 0)
            {
                _invisibleTick = StartCoroutine(InvisibleTick());
                _health = _maxHealth;
            }
        }
    }

    private void Hit()
    {
        foreach (Barrier barrier in _barriers.Barriers)
        {
            
        }
    }

    private IEnumerator InvisibleTick()
    {
        _isInvisible = true;
        yield return new WaitForSeconds(_invisibleTime);
        _isInvisible = false;
    }
}
