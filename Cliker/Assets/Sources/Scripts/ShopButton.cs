using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButton : MonoBehaviour
{
    public void MainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ShopScene()
    {
        SceneManager.LoadScene("Shop");
    }
}
