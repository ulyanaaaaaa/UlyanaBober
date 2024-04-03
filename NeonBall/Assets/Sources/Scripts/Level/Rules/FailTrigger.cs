using System;
using UnityEngine;

public class FailTrigger : PlayerTrigger
{
    public Action OnFail;

    private void Awake()
    {
        PlayerEnter += Finish;
    }

    private void Finish()
    {
        OnFail?.Invoke();
    }
}
