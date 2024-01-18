using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private int _count = 0;
    [SerializeField] private TextMeshProUGUI _counter;

    private void Update()
    {
        _counter.text = "���������: " + _count.ToString();
    }

    public void AddCount()
    {
        _count++;
    }
}
