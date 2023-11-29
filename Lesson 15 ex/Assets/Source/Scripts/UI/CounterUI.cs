using System;
using TMPro;
using UnityEngine;

public class CounterUI : MonoBehaviour
{
    public Action<int> OnCountChange;

    [SerializeField] private TextMeshProUGUI _counterText;
    private AudioSource _source;
    private int _count;

    public void AddCount(int value)
    {
        if (value < 0)
            throw new ArgumentException("Value must be positive");
        _count += value;
        OnCountChange?.Invoke(_count);
        UpdateUI();
    }

    private void UpdateUI()
    {
        _counterText.text = _count.ToString();
    }
}
