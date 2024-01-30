using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour //TODO:lvl load
{
    public void LoadMainScene() => SceneManager.LoadScene("SampleScene");

    public void LoadShopScene() => SceneManager.LoadScene("Shop");

    public void LoadSettingsScene() => SceneManager.LoadScene("Settings");
}
