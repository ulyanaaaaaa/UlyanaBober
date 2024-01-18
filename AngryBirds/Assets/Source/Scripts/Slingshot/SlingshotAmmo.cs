using UnityEngine;
using System;
using TMPro;
using System.Collections;

public class SlingshotAmmo : MonoBehaviour
{
    [SerializeField] private ShotPoint _point;
    [SerializeField] private BirdsFactory _factory;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _rubberPosition;
    [SerializeField] private float _delay;
    [SerializeField] private float _maxAmmo;
    [SerializeField] private TextMeshProUGUI _playStatusText;
    private float _currentAmmo;

    private void Awake()
    {
        _currentAmmo = _maxAmmo;
        NextBird();
        _point.OnReleaseShoot += NextBird;

    }

    private void Update()
    {
        CheckApples();
    }

    private void CheckApples()
    {
        int appleCount = GameObject.FindObjectsOfType(typeof(Apple)).Length;  //-
        if (appleCount == 0)
        {
            _playStatusText.text = "Победа!";
            _currentAmmo = 0;
        }
        if(_currentAmmo == 0 && appleCount >= 1)
        {
            _playStatusText.text = "Поражение!";
        }
    }

    private void NextBird()
    {
        
        if (_currentAmmo <= 0)
            return;
        _currentAmmo--;
        StartCoroutine(ReloadDelay());
    }

    private void CreateBird()
    {
        Bird newBird = _factory.CreateBird(_startPosition.position);
        newBird.Setup(_rubberPosition);
        _point.UpdateBird(newBird);
    }

    private IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(_delay);
        CreateBird();
    }
}
