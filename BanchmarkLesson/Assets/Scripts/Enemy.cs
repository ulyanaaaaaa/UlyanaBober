using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float minX = -6.78f, maxX = 6.78f;
    [SerializeField] private float _delay;
    [SerializeField] private Transform _spawnBallPosition;
    [field: SerializeField] public float Damage { get; private set; }
    private Rigidbody2D _rigidbody;
    private Player _player;
    private Coroutine _shootTick;

    public Enemy Setup(Player player)
    {
        _player = player;
        return this;
    }

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
        if (_player.IsTookBonus)
        {
            _rigidbody.velocity = (Vector2.down + new Vector2(Random.Range(-3, 3), 0)) * _speed/2;
        }
        else
        {
            _rigidbody.velocity = (Vector2.down + new Vector2(Random.Range(-3, 3), 0)) * _speed;
        }
    }
    
    public void Slowdown()
    {
        _speed /= 2;
    }
    
    public void Die()
    {
        int random = Random.Range(0, 100);
        if (random > 75)
            BonusSpawn();
        
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _player.Die();
        }
    }

    private void Shoot()
    {
        EnemyBomb ball = Resources.Load<EnemyBomb>("EnemyBomb");
        EnemyBomb newBall = Instantiate(ball, _spawnBallPosition.position, Quaternion.identity);
    }
    
    private void BonusSpawn()
    {
        Bonus bonus = Resources.Load<Bonus>("Bonus");
        Instantiate(bonus, transform.position, Quaternion.identity).Setup(_player);
    }

    private IEnumerator ShootTick()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(_delay);
        }
    }
}
