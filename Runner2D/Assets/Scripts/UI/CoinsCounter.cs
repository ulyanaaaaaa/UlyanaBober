using System;
using TMPro;
using UnityEngine;

public class CoinsCounter : MonoBehaviour
{
    private TextMeshProUGUI _counter;
    private Player _player;
    public Action OnAddCoin;

    private void Awake()
    {
        _counter = GetComponent<TextMeshProUGUI>();
        OnAddCoin += AddCoin;
    }

    public void Setup(Player player)
    {
        _player = player;
    }

    private void AddCoin()
    {
        _counter.text = $"Coins: {_player.Coins.Count.ToString()}";
    }
}
