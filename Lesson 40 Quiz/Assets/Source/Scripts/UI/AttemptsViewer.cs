using TMPro;
using UnityEngine;

public class AttemptsViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private JudgeHandle _judgeHandle;
    
    private void OnEnable()
    {
        _judgeHandle.OnAttemptsChange += UpdateView;
    }

    private void OnDisable()
    {
        _judgeHandle.OnAttemptsChange -= UpdateView;
    }

    private void UpdateView(int attempt)
    {
        _counter.text = $"Attempts: {attempt.ToString()}";
    }
}
