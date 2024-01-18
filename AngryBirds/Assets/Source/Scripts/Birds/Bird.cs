using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]

public class Bird : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;   
    [SerializeField] private Transform _startPoint;

    protected private Rigidbody2D _rigidbody;
    private bool _isCanLaunch = false;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.isKinematic = true;
    }

    public void Setup(Transform startPoint)
    {
        _shotPoint = startPoint;
        transform.DOJump(startPoint.position, 1, 1, 1).OnComplete(() =>
        {
            _isCanLaunch = true;
        });
    }

    private void Update()
    {
        if (_isCanLaunch)
        {
            transform.position = _shotPoint.position;
        }
    }

    public void Launch(Vector2 direction)
    { 
        _isCanLaunch = false;
        _rigidbody.isKinematic = false;       
        _rigidbody.AddForce(direction, ForceMode2D.Impulse);       
    }
}
