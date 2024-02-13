using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float Health;
    public Action OnDie;

    private void Awake()
    {
        OnDie += Die;
    }

    private void Die()
    {
        Destroy(gameObject);
        
    }
}
