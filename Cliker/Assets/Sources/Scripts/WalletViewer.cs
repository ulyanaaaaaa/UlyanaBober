using System;
using TMPro;
using UnityEngine;

public class WalletViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private Wallet _wallet;

    private void Awake() => _wallet.OnValueChanged += ChangeCounter;

    private void ChangeCounter(float value)
    {
        _counter.text = Math.Round(value, 1).ToString();
        
        if (value > 1000)
            _counter.text = $"{Math.Round(value/1000, 1)}K";
        
        if (value > 1000000)
            _counter.text = $"{Math.Round(value / 1000000, 1)}M";
    }
}
