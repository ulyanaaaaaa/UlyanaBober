using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void ButtonPlay()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonPlayQuit()
    {
        SceneManager.LoadScene(0);
    }
}
