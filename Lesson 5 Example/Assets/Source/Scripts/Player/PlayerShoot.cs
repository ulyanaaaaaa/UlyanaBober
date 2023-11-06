using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _delay;
    [SerializeField] private bool _canShoot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _canShoot == true) 
        {
            StartCoroutine(ShootTick());
        }
    }

    private void CreateBall() 
    {
        Ball ballCreated = Instantiate(_ball, _spawnPoint.position, Quaternion.identity).GetComponent<Ball>();
        ballCreated.Fly(_spawnPoint.transform.forward, 50);
        StartCoroutine(Delay());
    }

    private IEnumerator ShootTick() 
    {
        _canShoot = false;
        yield return new WaitForSeconds(_shootDelay);
        CreateBall();
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_delay);
        _canShoot = true;
    }
}
