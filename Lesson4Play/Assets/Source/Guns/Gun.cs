using System;
using System.Collections;
using UnityEngine;

class Gun : Hit
{
    public Action<float, float> OnAmmoChanged;

    [SerializeField] private protected Ball _ball;
    [SerializeField] private protected Transform _spawnPoint;
    [SerializeField] private protected float _delay;
    [SerializeField] private protected int _maxAmmo;
    [SerializeField] private protected float _reloadDelay;
    [SerializeField] private protected Material _redMaterial;
    [SerializeField] private protected Material _blackMaterial;
    
    [field: SerializeField] public bool CanShoot { get; set; }
    [field: SerializeField] public int Ammo { get; private protected set; }

    public virtual void Shoot()
    {
        CanShoot = false;
        Ball ballCreated = Instantiate(_ball, _spawnPoint.position, Quaternion.identity).GetComponent<Ball>();
        ballCreated.Fly(_spawnPoint.transform.forward, 50);
        Ammo--;
        OnAmmoChanged?.Invoke(Ammo, _maxAmmo);
        StartCoroutine(Delay());
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(_delay);
        if (Ammo < 0) CanShoot = false;
        else CanShoot = true;
    }

    public void Reload()
    {
        CanShoot = false;
        StartCoroutine(ReloadTick());
    }

    public IEnumerator ReloadTick()
    {
        yield return new WaitForSeconds(_reloadDelay);
        Ammo = _maxAmmo;
        CanShoot = true;
    }

    public virtual void ChangeTarget(Target _target)
    {
        _target.GetComponent<Renderer>().material = _redMaterial;
    }

    public override void Accept(IShootGun visiter)
    {
        visiter.Visit(this);
    }
}
