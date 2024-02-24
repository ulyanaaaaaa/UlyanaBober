using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Ball ball = Resources.Load<Ball>("Ball");
        Ball newBall = Instantiate(ball, transform.position, Quaternion.identity);
    }
}
