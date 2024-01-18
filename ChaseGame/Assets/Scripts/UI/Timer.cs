using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Action OnEnd;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private int _seconds;
    private int _secondsDone;
    private Coroutine _timerTick;

    private void Start()
    {
        _timerTick = StartCoroutine(TimerTick());
    }

    private IEnumerator TimerTick()
    {
        while (_secondsDone < _seconds)
        {
            yield return new WaitForSeconds(1);
            _secondsDone++;
            _text.text = (_seconds - _secondsDone).ToString();
        }
        OnEnd?.Invoke();
    }
}
