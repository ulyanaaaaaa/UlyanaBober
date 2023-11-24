using System.Collections;
using UnityEngine;
using DG.Tweening;

public class SlingshotAmmo : MonoBehaviour
{
    [SerializeField] private float _maxAmmo;
    [SerializeField] private float _delay;
    [SerializeField] private ShotRubber _point;
    [SerializeField] private BirdsFactory _factory;
    [SerializeField] private Transform _rubberPosition;
    [SerializeField] private Transform _startPosition;

    private float _currenAmmo;

    private void Awake()
    {
        _currenAmmo = _maxAmmo;
        NextBird();
        _point.OnReleaseShoot += NextBird;
    }

    private void NextBird() 
    {
        if (_currenAmmo <= 0)
            return;
        _currenAmmo--;
        StartCoroutine(ReloadDelay());
    }

    private void CreateBird()
    {
        Bird newBird = _factory.CreateBird(_startPosition.position);
        newBird.Setup(_rubberPosition, _startPosition);
        _point.UpdateBird(newBird);
    }

    private IEnumerator ReloadDelay() 
    {
        yield return new WaitForSeconds(_delay);
        CreateBird();
    }
}
