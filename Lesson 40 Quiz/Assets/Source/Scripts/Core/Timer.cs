using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Action OnEnd;
    public Action<float, float> OnDurationChanged;
    
    [SerializeField] private float _duration;
    [SerializeField] private QuizViewer _quizViewer;
    private float _startDuration;
    private Coroutine _tick;
    private void Awake()
    {
        _startDuration = _duration;
        _tick = StartCoroutine(Tick());
        _quizViewer.OnSelect += AttemptHandle;
    }

    private void AttemptHandle(bool right)
    {
        if(right)
            Restart();
    }
    
    private void Restart()
    {
        if(_tick != null)
            StopCoroutine(_tick);
        _duration = _startDuration;
        _tick = StartCoroutine(Tick());
    }

    public void Pause()
    {
        StopCoroutine(_tick);
    }

    private IEnumerator Tick()
    {
        while (_duration > 0)
        {
            yield return new WaitForSeconds(0.01f);
            _duration -= 0.01f;
            OnDurationChanged?.Invoke(_duration, _startDuration);
        }
        OnEnd?.Invoke();
    }
}
