using System;
using UnityEngine;

public class Abilities : MonoBehaviour
{
   [field: SerializeField] public float ValuePerClick { get; private set; } = 1;
   [field: SerializeField] public float ValuePerSecond { get; private set; } = 0;

    public void AddValuePerClick(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount must be positive");
        ValuePerClick += amount;
    }

    public void AddValuePerSecond(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount must be positive");
        ValuePerSecond += amount;
    }
}
