using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EntryPoint : MonoBehaviour
{
    [Space(20), Header("Parents point"), Space(5), SerializeField] 
    private Canvas _canvas;

    [Space(20), Header("Start point"), Space(5), SerializeField]
    private Transform _playerStartPoint;

    [SerializeField] public List<Transform> EnemyStartPoints;
    [SerializeField] private EnemySpawner _spawner;
    
    public PlayerMovement PlayerCreated;
    private PlayerMovement _player;
    private Timer _timer;
    private Timer _timerCreated;
    private WinWindow _winWindow;
    private FailWindow _failWindow;
    private BonusTimer _bonusTimer;
    private BonusTimer _bonusCreated;
    
    
    private List<IEntryPointSetupTimer> _setupsTimer = new List<IEntryPointSetupTimer>();
    private List<IEntryPointSetupBonusTimer> _setupsBonusTimer = new List<IEntryPointSetupBonusTimer>();
    public List<IEntryPointSetupPlayer> SetupsPlayer = new List<IEntryPointSetupPlayer>();

    private void Awake()
    {
        _player = Resources.Load<PlayerMovement>("Player");
        _timer = Resources.Load<Timer>("Timer");
        _winWindow = Resources.Load<WinWindow>("WinWindow");
        _failWindow = Resources.Load<FailWindow>("FailWindow");
        _bonusTimer = Resources.Load<BonusTimer>("BonusTime");
        CreateUI();
        CreatePlayer();
        Setup();
    }

    private void CreateUI()
    {
        _bonusCreated = Instantiate(_bonusTimer, _bonusTimer.GetComponent<RectTransform>().localPosition, Quaternion.identity, _canvas.transform);
        _bonusCreated.GetComponent<RectTransform>().localPosition = _bonusTimer.GetComponent<RectTransform>().localPosition;
        
        _timerCreated = Instantiate(_timer, _timer.GetComponent<RectTransform>().localPosition, Quaternion.identity, _canvas.transform);
        _timerCreated.GetComponent<RectTransform>().localPosition = _timer.GetComponent<RectTransform>().localPosition;
        _timerCreated.OnEnd += () => StopCoroutine(_spawner.RespawnEnemyTick);
        
        WinWindow winWindowCreated = Instantiate(_winWindow, _winWindow.GetComponent<RectTransform>().localPosition, Quaternion.identity, _canvas.transform);
        winWindowCreated.GetComponent<RectTransform>().localPosition = Vector3.zero;
        _setupsTimer.Add(winWindowCreated);
        
        FailWindow failWindowCreated = Instantiate(_failWindow, _failWindow.GetComponent<RectTransform>().localPosition, Quaternion.identity, _canvas.transform);
        failWindowCreated.GetComponent<RectTransform>().localPosition = Vector3.zero;
        SetupsPlayer.Add(failWindowCreated);
    }

    private void CreatePlayer()
    {
        PlayerCreated = Instantiate(_player, _playerStartPoint.position, Quaternion.identity);
    }

    private void Setup()
    {
        foreach (IEntryPointSetupTimer setupTimer in _setupsTimer)
        {
            setupTimer.Setup(_timerCreated);
        }
        foreach (IEntryPointSetupBonusTimer setupBonusTimer in _setupsBonusTimer)
        {
            setupBonusTimer.Setup(_bonusCreated);
        }
    }
}

public interface IEntryPointSetupPlayer
{
    public void Setup(PlayerMovement player);
}

public interface IEntryPointSetupTimer
{
    public void Setup(Timer timer);
}

public interface IEntryPointSetupBonusTimer
{
    public void Setup(BonusTimer bonusTimer);
}
