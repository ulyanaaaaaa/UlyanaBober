using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Cannon _currentCannon;


    [SerializeField] private Cannon _simpleCannon;
    [SerializeField] private Cannon _bigCannon;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _currentCannon.CanShoot && _currentCannon.Ammo > 0) 
        {
            _currentCannon.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _currentCannon.Reload();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            _simpleCannon.gameObject.SetActive(true);
            _bigCannon.gameObject.SetActive(false);
            _currentCannon = _simpleCannon;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _simpleCannon.gameObject.SetActive(false);
            _bigCannon.gameObject.SetActive(true);
            _currentCannon = _bigCannon;
        }
    }
}
