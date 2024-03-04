using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _spawnBallPosition;
    [SerializeField] private PlayerBomb _bomb;
    [SerializeField] private float minX, maxX;
    private Rigidbody2D _rigidbody;
    private EnemyFactory _enemyFactory;

    public bool IsTookBonus;

    public void Setup(EnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        transform.position = new Vector2(Math.Clamp(transform.position.x, minX, maxX), transform.position.y);
        
        if (Input.GetKey(KeyCode.A))
            _rigidbody.velocity = Vector2.left * _speed;

        if (Input.GetKey(KeyCode.D))
            _rigidbody.velocity = Vector2.right * _speed;
        
        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            _rigidbody.velocity = Vector2.zero;
        
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    private void Shoot()
    {
        PlayerBomb ball = Resources.Load<PlayerBomb>("PlayerBomb");
        PlayerBomb newBall = Instantiate(ball, _spawnBallPosition.position, Quaternion.identity);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bonus bonus))
        {
            IsTookBonus = true;
            bonus.Timer();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
