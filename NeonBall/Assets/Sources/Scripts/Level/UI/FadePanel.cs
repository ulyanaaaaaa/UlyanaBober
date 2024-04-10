using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Image _image;

    public void FadeOut(Action action)
    {
        _image.DOFade(0, _duration).OnComplete(() => action?.Invoke());
    }
    
    public void FadeIn(Action action)
    {
        _image.DOFade(1, _duration).OnComplete(() => action?.Invoke());
    }
}
