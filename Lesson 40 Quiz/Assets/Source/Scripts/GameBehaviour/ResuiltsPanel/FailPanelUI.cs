using System;
using UnityEngine;
using UnityEngine.UI;

public class FailPanelUI : MonoBehaviour
{
    [SerializeField] private JudgeHandle _judge;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private SceneLoadService _sceneLoadService;
    private void Awake()
    {
        if(_judge == null)
            throw new NullReferenceException($"Judge is null: {nameof(JudgeHandle)}");
        _judge.OnFail += Open;
    }

    private void Open()
    {
        _panel.SetActive(true);
        _restartButton.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        _sceneLoadService.Restart();
    }
}
