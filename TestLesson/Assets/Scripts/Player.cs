using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private int _coinsCount;
    [SerializeField] private float _damage;
    [SerializeField] private TextMeshProUGUI _coinsText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_spawner.Enemies.Count >= 1)
            {
                Hit(NearEnemy(), _damage);
                _coinsCount++;
                _coinsText.text = $"Coins: {_coinsCount.ToString()}";
            }
        }
    }
    
    private Enemy NearEnemy()
    {
        Enemy nearEnemy = _spawner.Enemies[0];

        for (int i = 0; i < _spawner.Enemies.Count; i++)
        {
            if (Vector2.Distance(_spawner.Enemies[i].transform.position, transform.position) <
                Vector2.Distance(nearEnemy.transform.position, transform.position))
            {
                nearEnemy = _spawner.Enemies[i];
            }
        }

        return nearEnemy;
    }

    private void Hit(Enemy enemy, float damage)
    {
        enemy.Hit(damage, _spawner);
    }
}
