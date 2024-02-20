using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour, IShoot
{
    [SerializeField] private protected Transform _spawnPoint;
    [SerializeField] private protected float _force;
    [SerializeField] private protected int _maxAmmo;
    [SerializeField] private protected int _ammo;
    [SerializeField] private protected float _reloadDelay;
    private protected bool _canShoot;
    
    public virtual void Shoot()
    {
        if (_canShoot)
        {
            _canShoot = false;
            Ball ball = Instantiate(Resources.Load<BigBall>("BigBall"), _spawnPoint.position, Quaternion.identity);
            ball.Fly(_spawnPoint.transform.right, _force);
            _ammo--;
        }
    }

    public virtual void Reload()
    {
        _canShoot = false;
        StartCoroutine(ReloadTick(_reloadDelay));
    }
    
    protected IEnumerator ReloadTick(float delay) 
    {
        yield return new WaitForSeconds(delay);
        _ammo = _maxAmmo;
        _canShoot = true;
    }
}
