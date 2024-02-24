using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
            _audio.Play();
        }
    }

    private void Shoot()
    {
        Ball ball = Resources.Load<Ball>("Ball");
        Ball newBall = Instantiate(ball, transform.position, Quaternion.identity);
    }
}
