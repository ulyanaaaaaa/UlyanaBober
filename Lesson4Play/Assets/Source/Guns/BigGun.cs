using System.Collections; 
using UnityEngine;

class BigGun : Gun    //????????? public ???????????
{
    [SerializeField] private float _delayBetweenShoot;

    public override void Accept(IShootGun visiter)
    {
        visiter.Visit(this);
    }

    public override void Shoot()
    {
        OnAmmoChanged?.Invoke(Ammo, _maxAmmo);
        StartCoroutine(DoubleShootTick());
    }

    public void DoubleShoot()
    {
        if (Ammo == 0)
            return;
        Ball ballCreated = Instantiate(_ball, _spawnPoint.position, Quaternion.identity).GetComponent<Ball>();
        ballCreated.Fly(_spawnPoint.transform.forward, 50);
        Ammo--;
    }

    private IEnumerator DoubleShootTick()
    {
        DoubleShoot();
        yield return new WaitForSeconds(_delayBetweenShoot);
        DoubleShoot();
        StartCoroutine(Delay());
    }

    public override void ChangeTarget(Target _target)
    {
        _target.GetComponent<Renderer>().material = _blackMaterial;
    }
}
