using System;
using TMPro;
using UnityEngine;

public class WalletViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private Wallet _wallet;

    private void Awake()
    {
        _wallet.OnValueChange += UpdateView;
    }

    private void UpdateView(float amount)
    {
        _counter.text = Math.Round(amount, 1).ToString();
        if (amount > 1000)
        {
            _counter.text = $"{Math.Round(amount / 1000,1)}k";
        }
    }
}
