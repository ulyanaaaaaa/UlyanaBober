using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Audio : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            _audioSource.Pause();

            if(Input.GetKey(KeyCode.E))
                _audioSource.UnPause();
        }
    } 
}