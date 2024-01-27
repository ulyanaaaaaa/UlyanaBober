using UnityEngine;
using UnityEngine.UI;

public class ScrollBarSettings : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbar;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("Volume"))
        {
            _audioSource.volume = PlayerPrefs.GetFloat("Volume");

            GameObject scrollBar = GameObject.FindWithTag("ScrollBar");
            
            if (scrollBar != null)
                _scrollbar.value = _audioSource.volume;
            
            else
                PlayerPrefs.SetFloat("Volume", _audioSource.volume);
        }
    }

    private void Update()
    {
        GameObject scrollBar = GameObject.FindWithTag("ScrollBar");
        
        if (scrollBar != null)
        {
            _scrollbar = scrollBar.GetComponent<Scrollbar>();
            _audioSource.volume = _scrollbar.value;
            
            PlayerPrefs.SetFloat("Volume", _audioSource.volume);
        }
    }
}
