using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private GroundChacker _chacker;

    private Rigidbody2D _rigidbody;
    private Coroutine _invisibleTick;
    private LifeCounter _lifeCounter;
    private InvisibleTimer _invisibleTimer;
    private bool _isInvisible;
    public int _life;

    public void Setup(LifeCounter lifeCounter, BarriersSpawner spawner, InvisibleTimer invisibleTimer)
    {
        _invisibleTimer = invisibleTimer;
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
        if (Input.GetKeyDown(KeyCode.Space) && _chacker.IsGround)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            DestroyNearestHitBarrier();
        }
    }

    private void Jump()
    {
        _chacker.IsGround = false;
        _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Barrier barrier))
        {
            barrier.OnDestroy?.Invoke();
            Hitten(barrier);
        }
    }
    
    private void Hitten(Barrier barrier)
    {
        if (_isInvisible)
            return;

        barrier.TakeDamage(this);
        _lifeCounter.CurrentLife(_life);
        _invisibleTimer.CurrentSeconds(_invisibleTime);
        _invisibleTick = StartCoroutine(InvisibleTick());
        if (_life == 0)
        {
            OnDie?.Invoke();
        }
    }

    private void DestroyNearestHitBarrier()
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
            return null;

        IEnumerable<Barrier> hitBarriersList = from hitBarriers in _spawner.Barriers
            where hitBarriers as HitBarrier
            select hitBarriers;

        if (hitBarriersList.Count() == 0)
            return null;
        
        Barrier nearestBarrier = hitBarriersList.First();

        foreach (HitBarrier barrier in hitBarriersList)
        {
            float distance = Vector2.Distance(barrier.transform.position, transform.position);

            if (distance < Vector2.Distance(nearestBarrier.transform.position, transform.position))
            {
                nearestBarrier = barrier;
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
