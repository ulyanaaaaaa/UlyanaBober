using System;
using UnityEngine;


public class Abilities : MonoBehaviour
{
    [field: SerializeField] public float ValuePerSecond { get; set; } 
    [field: SerializeField] public float ValuePerClick { get; set; }

    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void Start()
    {
        _wallet.OnLoad();
    }

    public void AddValuePerSecond(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Value must be positive!");
        
        ValuePerSecond += amount;
        _wallet.OnSave();
    }

    public void AddValuePerClick(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Value must be positive!");
        
        ValuePerClick += amount;
        _wallet.OnSave();
    }
}
