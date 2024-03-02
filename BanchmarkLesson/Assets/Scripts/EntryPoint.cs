using UnityEngine;

[RequireComponent(typeof(EnemyFactory))]
public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Transform _playerStartPoint;
    private Player _player;
    private EnemyFactory _enemyFactory;
    private Player _playerCreated;
    
    private void Awake()
    {
        _enemyFactory = GetComponent<EnemyFactory>();
        _player = Resources.Load<Player>("Player");
        CreatePlayer();
    }
    
    private void CreatePlayer()
    {
        _playerCreated = Instantiate(_player, _playerStartPoint.position, Quaternion.identity);
        _playerCreated.Setup(_enemyFactory);
        _enemyFactory.Setup(_playerCreated);
    }
}
