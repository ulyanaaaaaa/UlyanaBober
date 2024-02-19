using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour, IShoot
{
    [SerializeField] private protected float _force;
    [SerializeField] private protected int _maxAmmo;
    [SerializeField] private protected int _ammo;
    [SerializeField] private protected float _reloadDelay;
    private protected bool _canShoot;
    [SerializeField] private protected Transform _spawnPoint;

    public virtual void Shoot()
    {
        _canShoot = false;
        Ball ball = Instantiate(Resources.Load<Ball>("Ball"), _spawnPoint.position, Quaternion.identity);
        ball.Fly(_spawnPoint.transform.right, _force);
        _ammo--;
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
