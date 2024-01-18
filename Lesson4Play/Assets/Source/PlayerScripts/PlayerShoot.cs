using System;
using UnityEngine;

class PlayerShoot : MonoBehaviour
{
    public event Action OnActionActive;

    [SerializeField] public Gun CurrentCanon;
    [SerializeField] private Gun _simpleCanon;
    [SerializeField] private Gun _bigCanon;

    public void ApplyEvent()
    {
        OnActionActive?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && CurrentCanon.CanShoot && CurrentCanon.Ammo > 0)
        {
            ApplyEvent();
            CurrentCanon.Shoot();
            CurrentCanon.Accept(new ShootGun());
        }

        if (Input.GetKeyUp(KeyCode.R))
            CurrentCanon.Reload();

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            CurrentCanon = _simpleCanon;
            _simpleCanon.gameObject.SetActive(true);
            _bigCanon.gameObject.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            CurrentCanon = _bigCanon;
            _simpleCanon.gameObject.SetActive(false);
            _bigCanon.gameObject.SetActive(true);
        }
    }
}
