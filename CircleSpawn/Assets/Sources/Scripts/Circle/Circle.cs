using System;
using System.Collections;
using DG.Tweening;
using OpenCover.Framework.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Circle : MonoBehaviour
{
    private CounterUI _counter;
    private Vector3 _startPosition;
    private MeshRenderer _renderer;
    private int _count;
    private float _lifeTime;

    public Action OnClick;
    public Action OnDestroy;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public Circle Setup(CounterUI counter)
    {
        _counter = counter;
        return this;
    }

    public Circle SetColor(Color color)
    {
        _renderer.material.color = color;
        return this;
    }

    public Circle SetMoveType()
    {
        _startPosition = transform.position;
        transform.DOMove(_startPosition + new Vector3(1, 0), 1).OnComplete(() =>
        {
            transform.DOMove(_startPosition + new Vector3(1, 0), 1);
        }).SetLoops(-1, LoopType.Yoyo);
        return this;
    }

    public Circle SetLifeTime(float lifetime)
    {
        _lifeTime = lifetime;
        StartCoroutine(LifeTimeTick());
        return this;
    }

    public Circle SetCount(int count)
    {  
        _count = count;
        return this;
    }

    public void DestroyLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator LifeTimeTick()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }

    public void OnMouseDown()
    {
        _counter.AddCount(_count);
        OnClick?.Invoke();
        OnDestroy?.Invoke();
        Destroy(gameObject);
    }
}
