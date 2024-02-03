using UnityEngine;

public class EnemyFabrica : MonoBehaviour
{
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

    public void CreateRedEnemy(Vector3 position)
    {
        Enemy enemy = Instantiate(_redEnemy, position, Quaternion.identity);
        enemy.CreatedEnemy.Add(enemy.SetHealth(Random.Range(0, 100)).SetType(Enemies.Red));
    }

    public void CreateGreenEnemy(Vector3 position)
    {
        Enemy enemy = Instantiate(_greenEnemy, position, Quaternion.identity);
        enemy.CreatedEnemy.Add(enemy.SetHealth(Random.Range(0, 100)).SetType(Enemies.Green));
    }

    public void CreateBlackEnemy(Vector3 position)
    {
        Enemy enemy = Instantiate(_blackEnemy, position, Quaternion.identity);
        enemy.CreatedEnemy.Add(enemy.SetHealth(Random.Range(0, 100)).SetType(Enemies.Black));
    }

    public void CreateWhiteEnemy(Vector3 position)
    {
        Enemy enemy = Instantiate(_whiteEnemy, position, Quaternion.identity);
        enemy.CreatedEnemy.Add(enemy.SetHealth(Random.Range(0, 100)).SetType(Enemies.White));
    }

    public void CreateBlueEnemy(Vector3 position)
    {
        Enemy enemy = Instantiate(_blueEnemy, position, Quaternion.identity);
        enemy.CreatedEnemy.Add(enemy.SetHealth(Random.Range(0, 100)).SetType(Enemies.Blue));
    }
}
