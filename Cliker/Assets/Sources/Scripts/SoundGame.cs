using UnityEngine;

public class SoundGame : MonoBehaviour
{
    private void Awake()
    {
        GameObject objectGame = GameObject.FindWithTag("SoundGame");
        
        if (objectGame != null)
            Destroy(gameObject);
        
        else
        {
            gameObject.tag = "SoundGame";
            DontDestroyOnLoad(this.gameObject);
        }
    }
}