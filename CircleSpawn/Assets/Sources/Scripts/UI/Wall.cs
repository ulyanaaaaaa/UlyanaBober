using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Wall : MonoBehaviour
{
    private int _clickNumber;
    [SerializeField] TextMeshProUGUI _counterText;

    private void OnMouseUp()
    {
        _clickNumber++;
        if(_clickNumber == 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Update()
    {
        _counterText.text = "Промахи:" + _clickNumber.ToString();
    }
}
