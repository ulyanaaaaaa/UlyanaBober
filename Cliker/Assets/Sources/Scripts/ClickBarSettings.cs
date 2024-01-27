using UnityEngine;
using UnityEngine.UI;

public class ClickBarSettings : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbar;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("Sound"))
        {
            _audioSource.volume = PlayerPrefs.GetFloat("Sound");

            GameObject scrollBar = GameObject.FindWithTag("SoundBar");
            
            if (scrollBar != null)
                _scrollbar.value = _audioSource.volume;
            
            else
                PlayerPrefs.SetFloat("Sound", _audioSource.volume);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _audioSource.pitch = 1 + Random.Range(-0.1f, 0.1f); 
            _audioSource.Play();
        } 
        
        GameObject scrollBar = GameObject.FindWithTag("SoundBar");
        
        if (scrollBar != null)
        {
            _scrollbar = scrollBar.GetComponent<Scrollbar>();
            _audioSource.volume = _scrollbar.value;
            
            PlayerPrefs.SetFloat("Sound", _audioSource.volume);
        }
    }
}