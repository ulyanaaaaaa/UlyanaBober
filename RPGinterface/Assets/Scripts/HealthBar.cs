using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image _healthBar;
    [SerializeField] Button _plusHealth;
    [SerializeField] Button _minusHealth;

    private void Awake()
    {
        _plusHealth.onClick.AddListener(AddHeath);
        _minusHealth.onClick.AddListener(RemoveHealth);
    }

    private void AddHeath()
    {
        _healthBar.fillAmount += 0.1f;
    }

    private void RemoveHealth()
    {
        _healthBar.fillAmount -= 0.1f;
    }
}
