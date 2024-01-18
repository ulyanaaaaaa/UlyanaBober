using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private float _health = 100; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _health -= UnityEngine.Random.Range(10, 25);
            _healthBar.fillAmount = _health/100;
        }
    }
}
