using System;
using UnityEngine;
using DG.Tweening;

public class Diamond : MonoBehaviour
{
    public Action OnClick;

    public void OnMouseDown()
    {
        OnClick?.Invoke();
        transform.DOScale(0.5f, 0.2f).OnComplete(() => 
        {
            transform.DOScale(0.25f,0.2f);
        });
    }
}
