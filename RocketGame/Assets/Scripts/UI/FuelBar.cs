using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Rocket _rocket;

    public void Setup(Rocket rocket)
    {
        _rocket = rocket;
    }

    private void Update()
    {
        _image.fillAmount = _rocket.Fuel / 100;
    }
}