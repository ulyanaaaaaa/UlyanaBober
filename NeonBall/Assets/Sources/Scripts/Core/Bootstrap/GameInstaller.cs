using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private FinishTrigger _finishTrigger;
    [SerializeField] private LevelStateMachine _levelStateMachine;
    [SerializeField] private FailTrigger _failTrigger;
    public override void InstallBindings()
    {
        Container.Bind<IInput>()
            .To<KeyboardInput>()
            .AsSingle();
        
        Container.Bind<PauseService>()
            .FromComponentInNewPrefabResource(AssetsPath.ServicesPath.PauseService)
            .AsSingle();
        
        Container.Bind<SaveService>()
            .FromComponentInNewPrefabResource(AssetsPath.ServicesPath.SaveService)
            .AsSingle();
        
        Container.Bind<FailTrigger>()
            .FromInstance(_failTrigger)
            .AsSingle();
        
        Container.Bind<FinishTrigger>()
            .FromInstance(_finishTrigger)
            .AsSingle();
        
        Container.Bind<LevelStateMachine>()
            .FromInstance(_levelStateMachine)
            .AsSingle();
    }
}