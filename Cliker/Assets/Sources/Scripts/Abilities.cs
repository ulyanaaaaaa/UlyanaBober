using System;
using System.Diagnostics;
using UnityEngine;


public class Abilities : MonoBehaviour
{
    [field: SerializeField] public float ValuePerSecond { get; set; } 
    [field: SerializeField] public float ValuePerClick { get; set; }

    [SerializeField] private Wallet _wallet;

    private void Awake()
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
