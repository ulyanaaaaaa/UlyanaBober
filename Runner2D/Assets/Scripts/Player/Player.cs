using System;
using UnityEngine;

[RequireComponent(typeof(PlayerShoot))]
[RequireComponent(typeof(PlayerMovement))]

public class Player : MonoBehaviour
{
    public Action OnDie;
    
    private int _coins;
    private CoinsCounter _coinsCounter;
    private FailWindow _failWindow;
    private float _health = 100f;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            TakeDamage(enemy.Damage);

        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _coins++;
            _coinsCounter.AddCoin(_coins);
            coin?.OnDestroy();  
        }
    }

    public void Setup(CoinsCounter coinsCounter, FailWindow failWindow)
    {
        _coinsCounter = coinsCounter;
        _failWindow = failWindow;
    }

    private void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            OnDie.Invoke();
            Destroy(gameObject);
        }
    }
}
