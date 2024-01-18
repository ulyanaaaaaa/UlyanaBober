using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CounterUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _counterText;
    int _counter;

    public void AddCount(int value)
    {
        if(value < 0)
        {
            return;
        }
        _counter += value;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _counterText.text = _counter.ToString();
    }
}
