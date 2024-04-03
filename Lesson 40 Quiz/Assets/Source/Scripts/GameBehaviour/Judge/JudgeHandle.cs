using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class JudgeHandle : MonoBehaviour
{
    public Action OnFail;
    public Action<int> OnAttemptsChange;
    
    [SerializeField] private QuizViewer _quizViewer;
    [SerializeField] private int _attempts;
    [SerializeField] private Timer _timer;
    [SerializeField] private Volume _volume;
    private Vignette _vignette;

    private bool _isFail;

    private void Awake()
    {
        _quizViewer.OnSelect += ChoiceHandle;
        OnAttemptsChange?.Invoke(_attempts);
        _timer.OnEnd += Fail;
        if (_volume.profile.TryGet(out Vignette vignette))
        {
            _vignette = vignette;
        }
    }

    private void ChoiceHandle(bool right)
    {
        if(_isFail)
            return;

        if (!right)
        {
            _attempts--;
            OnAttemptsChange?.Invoke(_attempts);
            float vignetteValue = 0;
            DOTween.To(() => vignetteValue, x => vignetteValue = x, 0.5f, 0.5f).OnUpdate(() =>
            {
                _vignette.intensity.value = vignetteValue;
            }).OnComplete(() =>
            {
                DOTween.To(() => vignetteValue, x => vignetteValue = x, 0f, 0.5f).OnUpdate(() =>
                {
                    _vignette.intensity.value = vignetteValue;
                });
            });
        }

        if (_attempts <= 0)
        {
            Fail();
        }
    }

    private void Fail()
    {            
        _isFail = true;
        OnFail?.Invoke();
        _timer.Pause();
    }
}
