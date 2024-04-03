using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadService : MonoBehaviour
{
    public void Load(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
