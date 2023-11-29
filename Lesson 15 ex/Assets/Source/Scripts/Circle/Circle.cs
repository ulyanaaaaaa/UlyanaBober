using DG.Tweening;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public Action OnClick;
    public Action OnDestory;

    [SerializeField] private float _lifeTime;

    private CounterUI _counter;
    private Vector3 _startPosition;
    private MeshRenderer _renderer;
    private int _score = 1;

    private Coroutine _lifetimeTick;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _startPosition = transform.position;
    }

    private void Start()
    {
        _lifetimeTick = StartCoroutine(LifetimeTick());
    }

    public Circle Setup(CounterUI counter) 
    {
        _counter = counter;
        return this;
    }

    public Circle SetMoveType() 
    {
        _startPosition = transform.position;
        transform.DOMove(_startPosition + new Vector3(1, 0), 1).OnComplete(() =>
        {
            transform.DOMove(_startPosition + new Vector3(-1, 0), 1);
        }).SetLoops(-1, LoopType.Yoyo);
        return this;
    }

    public Circle SetColor(Color color) 
    {
        _renderer.material.color = color;
        return this;
    }
    
    public Circle SetScore(int score) 
    {
        if (score <= 0)
            throw new ArgumentOutOfRangeException("Value must be positive");
        _score = score; 
        return this;
    }
    
    public Circle SetLifetime(float lifetime) 
    {
        _lifeTime = lifetime;
        return this;
    }

    private void OnMouseDown()
    {
        _counter.AddCount(_score);
        OnClick?.Invoke();
        Kill();
    }

    private IEnumerator LifetimeTick() 
    {
        yield return new WaitForSeconds(_lifeTime);
        Kill();
    }

    private void Kill() 
    {
        StopCoroutine(_lifetimeTick);
        OnDestory?.Invoke();
        Destroy(gameObject);
    }
}
