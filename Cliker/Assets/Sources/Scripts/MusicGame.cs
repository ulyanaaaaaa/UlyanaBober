using UnityEngine;

public class MusicGame : MonoBehaviour
{
    private void Awake()
    {
        GameObject objectGame = GameObject.FindWithTag("Music");
        
        if (objectGame != null)
            Destroy(gameObject);
        
        else
        {
            gameObject.tag = "Music";
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
