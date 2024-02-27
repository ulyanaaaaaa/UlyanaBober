using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public Action OnDie;

    [SerializeField] private BarriersSpawner _spawner;
    [SerializeField] private int _maxLife = 3;
    [SerializeField] private int _invisibleTime = 3;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _nearbyDistance = 5f;

    private Rigidbody2D _rigidbody;
    private Coroutine _invisibleTick;
    private LifeCounter _lifeCounter;
    private bool _isInvisible;
    [SerializeField] private bool _isJump;
    public int _life;

    public void Setup(LifeCounter lifeCounter, BarriersSpawner spawner)
    {
        _lifeCounter = lifeCounter;
        _spawner = spawner;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _life = _maxLife;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJump)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            DestroyNearestBarrier();
        }
    }

    private void Jump()
    {
        _isJump = true;
        _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Barrier barrier))
        {
            barrier.OnDestroy?.Invoke();
            Hitten(barrier);
        }

        _isJump = collision.gameObject.TryGetComponent(out Ground ground)? false : true;
    }
    
    private void Hitten(Barrier barrier)
    {
        if (_isInvisible)
            return;

        barrier.TakeDamage(this);
        _lifeCounter.CurrentLife(_life);
        _invisibleTick = StartCoroutine(InvisibleTick());

        if (_life == 0)
        {
            OnDie?.Invoke();
        }
    }

    private void DestroyNearestBarrier()
    {
        Barrier nearestBarrier = FindNearestBarrier();

        if (nearestBarrier != null)
        {
            float distance = Vector2.Distance(nearestBarrier.transform.position, transform.position);
            
            if (distance > _nearbyDistance) //problem
            {
                nearestBarrier.OnDestroy?.Invoke();
            }
        }
    }

    private Barrier FindNearestBarrier()
    {
        if (_spawner.Barriers.Count == 0)
        {
            return null;
        }

        Barrier nearestBarrier = _spawner.Barriers[0];

        for (int i = 0; i < _spawner.Barriers.Count; i++)
        {
            float distance = Vector2.Distance(_spawner.Barriers[i].transform.position, transform.position);

            if (distance < Vector2.Distance(nearestBarrier.transform.position, transform.position))
            {
                nearestBarrier = _spawner.Barriers[i];
            }
        }

        return nearestBarrier;
    }

    private IEnumerator InvisibleTick()
    {
        _isInvisible = true;
        yield return new WaitForSeconds(_invisibleTime);
        _isInvisible = false;
    }
}
