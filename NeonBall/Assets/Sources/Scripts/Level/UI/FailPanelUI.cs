using UnityEngine;
using Zenject;

public class FailPanelUI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    private LevelStateMachine _levelStateMachine;

    [Inject]
    public void Constructor(LevelStateMachine levelStateMachine)
    {
        _levelStateMachine = levelStateMachine;
    }

    private void OnEnable()
    {
        _levelStateMachine.OnStateChange += LevelStateHandle;
    }

    private void OnDisable()
    {
        _levelStateMachine.OnStateChange -= LevelStateHandle;
    }

    public void LevelStateHandle(LevelState levelState)
    {
        if (levelState == LevelState.Fail)
            Open();
    }

    public void Open()
    {
        _panel.gameObject.SetActive(true);
    }
}
