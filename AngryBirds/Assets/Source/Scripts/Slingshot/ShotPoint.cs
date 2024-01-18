using System;
using UnityEngine;

public class ShotPoint : MonoBehaviour
{
    public Action OnReleaseShoot;
    public Vector2 Direction;

    [SerializeField] private float _maxDistance = 3;
    [SerializeField] private float _force;
    private Bird _bird;
    private Touch _touch;
    private Vector2 _start;
    private Camera _camera;
    private bool _isCanShoot = true;

    private void Awake()
    {
        _camera = Camera.main;
        _start = transform.position;
    }

    public void UpdateBird(Bird bird)
    {
        _bird = bird;
        _isCanShoot = true;
    }

    private void OnMouseDrag()
    {
        Vector2 target = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(_start, target) < _maxDistance)
        {
            transform.position = target;
        }
        else
        {
            Vector2 direction = (target - _start).normalized * _maxDistance;
            transform.position = _start + direction;
        }
    }

    private void OnMouseUp()
    {
        Vector2 releasePosition = transform.position;
        transform.position = _start;
        Vector2 delta = releasePosition - _start;       
        _bird.Launch(-delta * _force);         
        _bird = null;
        _isCanShoot = false;
        OnReleaseShoot?.Invoke();
    }
}
