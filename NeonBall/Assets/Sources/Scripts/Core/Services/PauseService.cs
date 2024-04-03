using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PauseService : MonoBehaviour
{
    private List<IPause> _pauses = new List<IPause>();

    public LevelStateMachine _levelStateMachine;

    [Inject]
    public void Constructor(LevelStateMachine levelStateMachine)
    {
        _levelStateMachine = levelStateMachine;
    }

    public void AddPause(IPause pause)
    {
        _pauses.Add(pause);
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
        if (levelState == LevelState.Finish || levelState == LevelState.Fail)
            Pause();
    }

    public void RemovePause(IPause pause)
    {
        _pauses.Remove(pause);
    }

    private void Pause()
    {
        foreach (IPause pause in _pauses)
        {
            pause.Pause();
        }
    }

    private void Resume()
    {
        foreach (IPause pause in _pauses)
        {
            pause.Resume();
        }
    }
}


