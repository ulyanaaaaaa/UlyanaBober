using System;
using UnityEngine;
using DG.Tweening;

public class Diamond : MonoBehaviour
{
    public Action OnClick;
    public Action OnClickText;
   

    public void OnMouseDown()
    {
        OnClick?.Invoke();
        OnClickText?.Invoke();
        transform.DOScale(2f, 0.2f).OnComplete(() =>
        {
            transform.DOScale(1.7f, 0.2f);
        });
    }
}
