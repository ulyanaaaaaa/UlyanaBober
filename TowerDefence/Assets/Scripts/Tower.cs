using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private protected float _shootDelay;
    [SerializeField] private protected float _damage;
    [SerializeField] private protected int _price;
    [SerializeField] private protected int _health;
    [SerializeField] private protected int _maxHealth;
    private Wallet _wallet;
    private Coroutine _shootTick;

    private void Start()
    {
        _shootTick = StartCoroutine(ShootTick());
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                UpdateLevel();
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Repair();
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

    protected virtual void Shoot()
    {
        
    }

    private IEnumerator ShootTick()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(_shootDelay);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
