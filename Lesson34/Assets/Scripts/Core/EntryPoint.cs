using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Transform _playerStartPoint;
    private Player _player;
    private Player _playerCreated;
    private FailWindow _failWindow;
    private FailWindow _failWindowCreated;
    private LifeCounter _lifeCounter;
    private LifeCounter _lifeCounterCreated;
    private BarriersSpawner _spawner;

    private void Awake()
    {
        _player = Resources.Load<Player>("Player");
        _failWindow = Resources.Load<FailWindow>("FailWindow");
        _lifeCounter = Resources.Load<LifeCounter>("LifeCounter");
        _spawner = GetComponent<BarriersSpawner>();
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

        _lifeCounterCreated = Instantiate(_lifeCounter,
            _lifeCounter.GetComponent<RectTransform>().localPosition,
            Quaternion.identity,
            _canvas.transform);
        _lifeCounterCreated.GetComponent<RectTransform>().localPosition = _lifeCounter.GetComponent<RectTransform>().localPosition;
    }

    private void CreatePlayer()
    {
        _playerCreated = Instantiate(_player, _playerStartPoint.position, Quaternion.identity);
        _playerCreated.Setup(_lifeCounterCreated, _spawner);
        _failWindowCreated.Setup(_playerCreated);
    }
}
