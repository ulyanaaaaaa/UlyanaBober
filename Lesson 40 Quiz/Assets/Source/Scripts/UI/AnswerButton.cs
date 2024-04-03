using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AnswerButton : MonoBehaviour
{
    public Action<Answer> OnClick;
    
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private Image _image;
    private Color _bufferColor;
    public Button Button { get; private set; }
    public Answer Answer { get; private set; }

    private void Awake()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(() => OnClick?.Invoke(Answer));
        _bufferColor = _image.color;
    }

    public void Setup(Answer answer)
    {
        Answer = answer;
        _title.text = Answer.Value;
    }

    public void Fail()
    {
        _image.DOColor(Color.red, 0.25f).OnComplete(() =>
        {
            _image.DOColor(_bufferColor, 0.25f);
        });
    }
}
