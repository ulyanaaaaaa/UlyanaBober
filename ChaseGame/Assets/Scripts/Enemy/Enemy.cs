using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyHealth))]

public class Enemy : MonoBehaviour, IEntryPointSetupPlayer
{
    public Action OnHit;
    
    private Transform _player;
    private NavMeshAgent _agent;
    private EnemyHealth _health;
    [SerializeField] private float _damage;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _health = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (!_player)
            return;
        _agent.SetDestination(_player.position);
        OnHit?.Invoke();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent(out PlayerHealth playerHealth))
        {
            if (!playerHealth.IsTookBasicBonus)
                playerHealth.TakeDamage(_damage);
            
            else
                _health.TakeDamage(_damage);
        }
    }

    public void Setup(PlayerMovement player)
    {
        _player = player.transform;
    }
}
