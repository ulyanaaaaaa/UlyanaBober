using UnityEngine;

public class Enemy : MonoBehaviour, IEntryPointSetupEnemy
{
    enum Enemies
    {
        Red,
        Green,
        Black,
        Blue,
        White
    }

    private float _health;
    private string type;
    private Transform _enemy;

    public void Setup(Enemy enemy) => _enemy = enemy.transform;

    public Enemy SetHealth(float health)
    {
        _health = health;
        return this;
    }
}
