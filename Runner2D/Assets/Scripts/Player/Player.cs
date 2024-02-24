using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerShoot))]
[RequireComponent(typeof(PlayerMovement))]

public class Player : MonoBehaviour
{
    public List<Coin> Coins;
    private CoinsCounter _coinsCounter;
    private FailWindow _failWindow;
    private float _health = 100f;

    public Action OnDie;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            TakeDamage(enemy.Damage);

        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            Coins.Add(coin);
            _coinsCounter?.OnAddCoin();
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
            OnDie?.Invoke();
        }
    }
}
