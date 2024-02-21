using UnityEngine;
using UnityEngine.EventSystems;

public class Box : MonoBehaviour, ISetup
{
    [SerializeField] private Player _player;
    [SerializeField] private float _health;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Object Clicked");
            TakeDamage(_player.Damage);
        }
    }
    
    public void Setup(Player player)
    {
        _player = player;
    }

    private void TakeDamage(float damage)
    {
        _health -= damage;
        
        if(_health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
