using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{
    public void MainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }
}
