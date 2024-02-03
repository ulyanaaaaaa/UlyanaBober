using UnityEngine;

public class EnemyFabrica : MonoBehaviour
{
    [SerializeField] private EntryPoint _entryPoint;
    
    private Enemy _redEnemy;
    private Enemy _greenEnemy;
    private Enemy _blackEnemy;
    private Enemy _whiteEnemy;
    private Enemy _blueEnemy;

    private void Awake()
    {
        _redEnemy = Resources.Load<Enemy>("RedEnemy");
        _greenEnemy = Resources.Load<Enemy>("GreenEnemy");
        _blackEnemy = Resources.Load<Enemy>("BlackEnemy");
        _whiteEnemy = Resources.Load<Enemy>("WhiteEnemy");
        _blueEnemy = Resources.Load<Enemy>("BlueEnemy");
    }

    public void CreateRedEnemy(Transform position) =>
        _entryPoint.SetupEnemies.Add(Instantiate(_redEnemy, position.position, Quaternion.identity).SetHealth(100));

    public void CreateGreenEnemy(Transform position) =>
        _entryPoint.SetupEnemies.Add(Instantiate(_greenEnemy, position.position, Quaternion.identity).SetHealth(75));

    public void CreateBlackEnemy(Transform position) =>
        _entryPoint.SetupEnemies.Add(Instantiate(_blackEnemy, position.position, Quaternion.identity).SetHealth(21));
    
    public void CreateWhiteEnemy(Transform position) => 
        _entryPoint.SetupEnemies.Add(Instantiate(_whiteEnemy, position.position, Quaternion.identity).SetHealth(55));

    public void CreateBlueEnemy(Transform position) =>
        _entryPoint.SetupEnemies.Add(Instantiate(_blueEnemy, position.position, Quaternion.identity).SetHealth(86));
}
