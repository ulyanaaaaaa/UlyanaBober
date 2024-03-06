using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;
    private Coroutine _shootTick;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _shootTick = StartCoroutine(ShootTick());
    }

    private void Update()
    {
        _rigidbody.velocity = Vector3.forward * _speed;
    }

    private void Shoot()
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out MainTower tower))
        {
            tower.Destroy();
        }
    }
}
