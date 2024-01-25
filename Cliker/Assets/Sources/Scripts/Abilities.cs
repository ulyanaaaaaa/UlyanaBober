using System;
using System.Diagnostics;
using UnityEngine;


public class Abilities : MonoBehaviour
{
    [field: SerializeField] public float ValuePerSecond { get; private set; } 
    [field: SerializeField] public float ValuePerClick { get; private set; }

    private void Awake()
    {
        Load();
    }

    private void Load()
    {
        if (PlayerPrefs.GetFloat("ValuePerClick") != 0)
        {
            ValuePerClick = PlayerPrefs.GetFloat("ValuePerClick");
        }
        if (PlayerPrefs.GetFloat("ValuePerSecond") != 0)
        {
            ValuePerSecond = PlayerPrefs.GetFloat("ValuePerSecond");
        }
    }

    public void AddValuePerSecond(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Value must be positive!");
        ValuePerSecond += amount;
        PlayerPrefs.SetFloat("ValuePerSecond", ValuePerSecond);
    }

    public void AddValuePerClick(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Value must be positive!");
        ValuePerClick += amount;
        PlayerPrefs.SetFloat("ValuePerClick", ValuePerClick);
    }
}
