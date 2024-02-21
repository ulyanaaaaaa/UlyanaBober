using UnityEngine;

public class SmallGun : Gun
{
    public override void Shoot()
    {
        if (_canShoot)
        {
            _canShoot = false;
            Ball ball = Instantiate(Resources.Load<BigBall>("BigBall"), _spawnPoint.position, Quaternion.identity);
            ball.Fly(_spawnPoint.transform.right, _force);
            _ammo--;
            _canShoot = true;
        }
    }
    
    public override void Reload()
    {
        _canShoot = false;
        StartCoroutine(ReloadTick(_reloadDelay));
    }
}

