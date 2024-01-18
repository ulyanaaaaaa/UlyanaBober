using UnityEngine.SceneManagement;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public void ButtonSettings()
    {
        SceneManager.LoadScene(2);
    }
    public void ButtonSettingsQuit()
    {
        SceneManager.LoadScene(0);
    }
}
