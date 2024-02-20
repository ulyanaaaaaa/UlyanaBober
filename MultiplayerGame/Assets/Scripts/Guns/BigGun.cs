using UnityEngine;

public class BigGun : Gun
{
    public override void Shoot()
    {
        if (_canShoot)
        {
            _canShoot = false;
            Ball ball = Instantiate(Resources.Load<BigBall>("BigBall"), _spawnPoint.position, Quaternion.identity);
            ball.Fly(_spawnPoint.transform.right, _force);
            _ammo--;
        }
    }
    
    public override void Reload()
    {
        _canShoot = false;
        StartCoroutine(ReloadTick(_reloadDelay));
    }
}
