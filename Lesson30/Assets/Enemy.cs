using System.Collections;
using UnityEngine;

public enum Hand
{
    Stone, 
    Paper, 
    Scissors
};

public class Enemy : MonoBehaviour
{
    public Hand Hand;
    private Timer _timer;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
    }

    public void SetRandomHand()
    {
        StartCoroutine(_timer.TimerTick());
        Hand = (Hand) Random.Range(0, 3);
    }
}
