using TMPro;
using UnityEngine;

public class CoinsCounter : MonoBehaviour
{
    private TextMeshProUGUI _counter;

    private void Awake()
    {
        _counter = GetComponent<TextMeshProUGUI>();
    }

    public void AddCoin(int count)
    {
        _counter.text = $"Coins: {count.ToString()}";
    }
}
