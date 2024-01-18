using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailWindow : MonoBehaviour, IEntryPointSetupPlayer
{
    [SerializeField] private GameObject _window;
    [SerializeField] private Button _restart;

    private void Awake()
    {
        _restart.onClick.AddListener(Restart);
        _window.SetActive(false);
    }

    private void Open()
    {
        _window.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    private void Restart() => SceneManager.LoadScene("SampleScene");

    public void Setup(PlayerMovement player)
    {
        player.GetComponent<PlayerHealth>().OnDie += Open;
    }
}
