using TMPro;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    private TextMeshProUGUI _counter;

    private void Awake()
    {
        _counter = GetComponent<TextMeshProUGUI>();
    }

    public void CurrentLife(int life)
    {
        _counter.text = $"Life: {life.ToString()}";
    }
}
