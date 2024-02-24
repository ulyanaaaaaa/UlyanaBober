using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Transform _playerStartPoint;
    private WinWindow _winWindow;
    private Player _player;
    private FailWindow _failWindow;
    private CoinsCounter _coinsCounter;

    private void Awake()
    {
        _winWindow = Resources.Load<WinWindow>("WinWindow");
        _player = Resources.Load<Player>("Player");
        _failWindow = Resources.Load<FailWindow>("FailWindow");
        _coinsCounter = Resources.Load<CoinsCounter>("CoinsCounter");
        CreateUI();
        CreatePlayer();
    }

    private void CreateUI()
    {
        WinWindow winWindowCreated = Instantiate(_winWindow, 
            _winWindow.GetComponent<RectTransform>().localPosition, 
            Quaternion.identity, 
            _canvas.transform);
        winWindowCreated.GetComponent<RectTransform>().localPosition = Vector3.zero;
        
        FailWindow failWindowCreated = Instantiate(_failWindow, 
            _failWindow.GetComponent<RectTransform>().localPosition, 
            Quaternion.identity, 
            _canvas.transform);
        failWindowCreated.GetComponent<RectTransform>().localPosition = Vector3.zero;
        failWindowCreated.Setup(_player);

        CoinsCounter coinsCounterCreated = Instantiate(_coinsCounter,
            _coinsCounter.GetComponent<RectTransform>().localPosition,
            Quaternion.identity,
            _canvas.transform);
        coinsCounterCreated.Setup(_player);
    }

    private void CreatePlayer()
    {
        Player playerCreated = Instantiate(_player, _playerStartPoint.position, Quaternion.identity);
        playerCreated.Setup(_coinsCounter, _failWindow);
    }
}
