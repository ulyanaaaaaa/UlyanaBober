using UnityEngine;

public class SkySound : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void SkyStep()
    {
        _audioSource.pitch = 1 + Random.Range(-0.1f, 0.1f); 
        _audioSource.Play();
    }
}
