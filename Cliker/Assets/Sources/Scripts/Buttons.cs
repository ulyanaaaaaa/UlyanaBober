using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void MainScene() => SceneManager.LoadScene("SampleScene");

    public void ShopScene() => SceneManager.LoadScene("Shop");

    public void SettingsScene() => SceneManager.LoadScene("Settings");
}
