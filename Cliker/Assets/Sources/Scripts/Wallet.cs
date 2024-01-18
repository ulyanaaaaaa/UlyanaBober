using System;
using System.Collections;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public Action<float> OnValueChanged;
    [SerializeField] private Diamond _diamond;
    [SerializeField] public float Value;
    [SerializeField] private Abilities _abilities; 

    private void Awake()
    {
        Load();
        _diamond.OnClick += Click;
        StartCoroutine(SecondTick());
    }

    private void Load()
    {
        if (PlayerPrefs.GetFloat("Value") != 0)
        {
            Value = PlayerPrefs.GetFloat("Value");
        }
    }

    private void Click()
    {
        AddValue(_abilities.ValuePerClick);
    }

    private void AddValue(float amount)
    {
        if(amount < 0)
            throw new ArgumentException("Value must be positive!");

        Value += amount;
        PlayerPrefs.SetFloat("Value", Value);
        OnValueChanged?.Invoke(Value);
    }

    private void RemoveValue(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Value must be positive!");

        Value -= amount;
        OnValueChanged?.Invoke(Value);
    }

    public bool TrySpend(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Value must be positive!");

        if (amount > Value)
        {
            return false;
        }
        else
        {
            RemoveValue(amount);
            return true;
        }
    }

    private IEnumerator SecondTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            AddValue(_abilities.ValuePerSecond);
        } 
    }
}
