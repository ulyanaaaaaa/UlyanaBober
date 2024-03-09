using System.Collections;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _health;
    [SerializeField] private protected Transform _shootPoint;
    private Rigidbody _rigidbody;
    private Coroutine _shootTick;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _shootTick = StartCoroutine(ShootTick());
    }

    private void Update()
    {
        _rigidbody.velocity = Vector3.left * _speed;
    }
    
    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new WarningException("Out of range");
        
        _health -= _damage;
        
        if (_health <= 0)
            Destroy();
    }

    private void Shoot()
    {
        EnemyBall enemyBall = Resources.Load<EnemyBall>("EnemyBall");
        Instantiate(enemyBall, _shootPoint.position, Quaternion.identity);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
    
    private IEnumerator ShootTick()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(_shootDelay);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Tower tower))
        {
            tower.Destroy();
        }
    }

}
