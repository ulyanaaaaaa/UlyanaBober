using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Barrier : MonoBehaviour
{
    [SerializeField] private protected float _speed;
    private Rigidbody2D _rigidbody;
    private BarriersSpawner _spawner;
    public Action OnDestroy;

    public Barrier Setup(BarriersSpawner spawner)
    {
        _spawner = spawner;
        return this;
    }
    
    private void Awake()
    {
        OnDestroy += Destroy;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody.velocity = Vector2.left * _speed;
    }
    
    private void Destroy()
    {
        _spawner.Barriers.Remove(this);
        Destroy(gameObject);
    }

    public void TakeDamage(Player player)
    {
        player._life--;
    }
}
