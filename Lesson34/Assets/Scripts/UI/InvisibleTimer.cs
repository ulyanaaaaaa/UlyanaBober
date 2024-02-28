using System.Collections;
using TMPro;
using UnityEngine;

public class InvisibleTimer : MonoBehaviour
{
    private TextMeshProUGUI _counter;
    private Coroutine _timerTick;

    private void Awake()
    {
        _counter = GetComponent<TextMeshProUGUI>();
    }

    public void CurrentSeconds(int seconds)
    {
        StartCoroutine(TimerTick(seconds));
    }

    private IEnumerator TimerTick(int seconds)
    {
        for (int i = 0; i < seconds + 1; i++)
        {
            _counter.text = $"Seconds: {(seconds - i).ToString()}";
            
            if (seconds - i == 0)
                _counter.text = " ";
            
            yield return new WaitForSeconds(1);
        }
    }
}
