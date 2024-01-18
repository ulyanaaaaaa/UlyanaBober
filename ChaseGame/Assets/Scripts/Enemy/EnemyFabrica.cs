using UnityEngine;

public class EnemyFabrica : MonoBehaviour
{
    private Enemy _basicEnemy;
    private Enemy _ghostEnemy;
    private Enemy _demonEnemy;
    [SerializeField] private EntryPoint _entryPoint;

    private void Awake()
    {
        _basicEnemy = Resources.Load<Enemy>("Enemy");
        _ghostEnemy = Resources.Load<Enemy>("GhostEnemy");
        _demonEnemy = Resources.Load<Enemy>("DemonEnemy");
    }
    
    //что возвращать
    public void CreateBasic(Transform position)
    {
        IEntryPointSetupPlayer enemy = Instantiate(_basicEnemy, position.position, Quaternion.identity);
        _entryPoint.SetupsPlayer.Add(enemy);
    }
    
    public IEntryPointSetupPlayer CreateGhost(Transform position)
    {
        IEntryPointSetupPlayer ghostEnemy = Instantiate(_ghostEnemy, position.position, Quaternion.identity);
        _entryPoint.SetupsPlayer.Add(ghostEnemy);
        return ghostEnemy;
    }
    
    public IEntryPointSetupPlayer CreateDemon(Transform position)
    {
        IEntryPointSetupPlayer demonEnemy = Instantiate(_demonEnemy, position.position, Quaternion.identity);
        _entryPoint.SetupsPlayer.Add(demonEnemy);
        return demonEnemy;
    }
}
