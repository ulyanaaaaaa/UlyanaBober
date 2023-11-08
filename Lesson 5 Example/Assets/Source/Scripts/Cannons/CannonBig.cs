using System.Collections;
using UnityEngine;

public class CannonBig : Cannon
{
    [SerializeField] private float _delayBetweenShoot;

    public override void Shoot()
    {
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
}
