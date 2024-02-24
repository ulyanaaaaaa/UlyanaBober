using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Transform _playerStartPoint;
    private Player _player;
    private Player _playerCreated;
    private FailWindow _failWindow;
    private FailWindow _failWindowCreated;
    private CoinsCounter _coinsCounter;
    private CoinsCounter _coinsCounterCreated;

    private void Awake()
    {
        _player = Resources.Load<Player>("Player");
        _failWindow = Resources.Load<FailWindow>("FailWindow");
        _coinsCounter = Resources.Load<CoinsCounter>("CoinsCounter");
        CreateUI();
        CreatePlayer();
    }

    private void CreateUI()
    {
        _failWindowCreated = Instantiate(_failWindow, 
            _failWindow.GetComponent<RectTransform>().localPosition, 
            Quaternion.identity, 
            _canvas.transform);
        _failWindowCreated.GetComponent<RectTransform>().localPosition = Vector3.zero;

        _coinsCounterCreated = Instantiate(_coinsCounter,
            _coinsCounter.GetComponent<RectTransform>().localPosition,
            Quaternion.identity,
            _canvas.transform);
        _coinsCounterCreated.GetComponent<RectTransform>().localPosition = _coinsCounter.GetComponent<RectTransform>().localPosition;
    }

    private void CreatePlayer()
    {
        _playerCreated = Instantiate(_player, _playerStartPoint.position, Quaternion.identity);
        _playerCreated.Setup(_coinsCounterCreated, _failWindowCreated);
        _failWindowCreated.Setup(_playerCreated);
    }
}
