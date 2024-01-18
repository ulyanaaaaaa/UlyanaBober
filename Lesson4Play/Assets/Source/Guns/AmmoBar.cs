using UnityEngine;
using UnityEngine.UI;


public class AmmoBar : MonoBehaviour
{
    [SerializeField] private Image _ammoBar;
    [SerializeField] private BigGun _bigGun;
    [SerializeField] private Gun _gun;

    private void Start()
    {
        _bigGun.OnAmmoChanged += DisplayAmmo;
        _gun.OnAmmoChanged += DisplayAmmo;
    }

    private void DisplayAmmo(float ammo, float maxAmmo)
    {
        _ammoBar.fillAmount = ammo / maxAmmo;
    }
}
