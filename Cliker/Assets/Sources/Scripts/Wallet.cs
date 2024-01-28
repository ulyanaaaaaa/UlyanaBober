using System;
using System.Collections;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public Action<float> OnValueChanged;

    [SerializeField] private Diamond _diamond;
    [SerializeField] public float Value; 
    
    private Abilities _abilities;
    private Save _save;

    private void Awake()
    { 
        _save = GetComponent<Save>();
        _abilities = GetComponent<Abilities>();

        OnLoad();

        _diamond.OnClick += Click;
        StartCoroutine(SecondTick());
    }

    public void OnSave()
    {
        SaveData _saveData = new SaveData(Value, _abilities.ValuePerClick, _abilities.ValuePerSecond);
        _save.SaveValue(_saveData);
    }

    public void OnLoad()
    {
        SaveData _saveData = new SaveData();
        _save.Load(_saveData);
        Value = _saveData.Value;
        _abilities.ValuePerClick = _saveData.ValuePerClick;
        _abilities.ValuePerSecond = _saveData.ValuePerSecond;
    }

    private void Click() => AddValue(_abilities.ValuePerClick);

    private void AddValue(float amount)
    {
        if(amount < 0)
            throw new ArgumentException("Value must be positive!");

        Value += amount;
        
        OnSave();
        OnValueChanged?.Invoke(Value);
    }

    private void RemoveValue(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Value must be positive!");

        Value -= amount;
        
        OnSave();
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
