using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinWindow : MonoBehaviour, IEntryPointSetupTimer
{
    [SerializeField] private GameObject _winWindow;
    [SerializeField] private Button _winRestart;

    private void Awake()
    {
        _winRestart.onClick.AddListener(Restart);
        _winWindow.SetActive(false);
    }

    private void Open()
    {
        _winWindow.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    private void Restart() => SceneManager.LoadScene("SampleScene");

    public void Setup(Timer timer)
    {
        timer.OnEnd += Open;
    }
}
