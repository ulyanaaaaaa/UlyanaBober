using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;
    [SerializeField] private Transform _spawnBallPosition;
    [field: SerializeField] public float Damage { get; private set; }
    private Rigidbody2D _rigidbody;
    private Coroutine _shootTick;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _shootTick = StartCoroutine(ShootTick());
    }

    private void Update()
    {
        _rigidbody.velocity = Vector2.down * _speed;
    }

    private void Shoot()
    {
        EnemyBomb ball = Resources.Load<EnemyBomb>("EnemyBomb");
        EnemyBomb newBall = Instantiate(ball, _spawnBallPosition.position, Quaternion.identity);
    }

    private IEnumerator ShootTick()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(_delay);
        }
    }
    
    public void Die()
    {
        Destroy(gameObject);
    }
}
