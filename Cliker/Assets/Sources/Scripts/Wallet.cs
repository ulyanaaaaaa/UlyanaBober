using System;
using System.Collections;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class Wallet : MonoBehaviour
{
    public Action<float> OnValueChanged;
    [SerializeField] private Diamond _diamond;
    [SerializeField] public float Value; 
    private Abilities _abilities;
    private Save _save;

    private void Awake()
    {
        _abilities = GetComponent<Abilities>();
        _save = GetComponent<Save>();
            
        SaveData _saveData = new SaveData(Value, _abilities.ValuePerClick, _abilities.ValuePerSecond);
        
        Load();
        _diamond.OnClick += Click;
        StartCoroutine(SecondTick());
        
        _save.SaveValue(_saveData);
        _save.Load(_saveData);
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
