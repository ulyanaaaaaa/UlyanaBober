using DG.Tweening;
using UnityEngine;

public class PingPongTextEffect : MonoBehaviour
{
    private void Awake()
    {
        transform.DOScale(1.2f, 2).SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(new Vector3(0,0,-20), 2).SetLoops(-1, LoopType.Yoyo);
    }
}
