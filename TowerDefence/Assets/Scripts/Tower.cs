using System.Collections;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Tower : MonoBehaviour
{
    [SerializeField] private protected float _shootDelay;
    [SerializeField] private protected int _price;
    [SerializeField] private protected float _damage;
    [SerializeField] private protected float _health;
    [SerializeField] private protected int _maxHealth;
    [SerializeField] private protected Transform _shootPoint;
    private Coroutine _shootTick;
    private protected Wallet _wallet;

    private void Start()
    {
        _shootTick = StartCoroutine(ShootTick());
    }
    
    private void Update()
    {
        CheckMouseButtons();
    }
    
    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new WarningException("Out of range");
        
        _health -= damage;
        
        if (_health <= 0)
            Destroy();
    }
    
    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void CheckMouseButtons()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    UpdateLevel();
                }
            }
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    _wallet.RemoveMoney(_price);
                    Repair();
                }
            }
        }
    }

    private void UpdateLevel()
    {
        _wallet.RemoveMoney(_price);
        _price *= 2;
        _damage *= 1.1f;
    }

    private void Repair()
    {
        _health = _maxHealth;
    }

    private void Shoot()
    {
        TowerBall towerBall = Resources.Load<TowerBall>("TowerBall");
        towerBall.SetDamage(_damage);
        Instantiate(towerBall, _shootPoint.position, Quaternion.identity);
    }

    private IEnumerator ShootTick()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(_shootDelay);
        }
    }
}
