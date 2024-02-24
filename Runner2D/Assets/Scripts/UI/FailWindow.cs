using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailWindow : MonoBehaviour
{
    [SerializeField] private GameObject _window;
    [SerializeField] private Button _restart;

    private void Awake()
    {
        _restart.onClick.AddListener(Restart);
        _window.SetActive(false);
    }

    public void Setup(Player player)
    {
        player.OnDie += Open;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    private void Open()
    {
        _window.SetActive(true);
    }
}
