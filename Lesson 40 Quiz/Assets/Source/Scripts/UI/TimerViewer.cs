using UnityEngine;
using UnityEngine.UI;

public class TimerViewer : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _bar;
    
    private void Awake()
    {
        _timer.OnDurationChanged += UpdateView;
    }

    private void UpdateView(float currentDuration, float maxDuration)
    {
        float persent = currentDuration / maxDuration;
        _bar.fillAmount = persent;
        _bar.color = _gradient.Evaluate(persent);
    }
}
