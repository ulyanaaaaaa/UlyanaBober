using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Transform _spawnPosition;
    private IShoot currentGun;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentGun = Instantiate(Resources.Load<Gun>("Gun"), _spawnPosition.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
            currentGun = Instantiate(Resources.Load<BigGun>("BigGun"), _spawnPosition.position, Quaternion.identity);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            currentGun = Instantiate(Resources.Load<SmallGun>("SmallGun"), _spawnPosition.position, Quaternion.identity);

        if (Input.GetKeyDown(KeyCode.F))
            currentGun.Shoot();
        
        if (Input.GetKeyDown(KeyCode.R))
            currentGun.Reload();

        if (_health <= 0)
            Die();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out SmallBall smallBall))
        {
            _health -= smallBall.Damage;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
