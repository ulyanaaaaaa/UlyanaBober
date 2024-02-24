using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _speed;
    public Action OnDestroy;

    private void Awake()
    {
        OnDestroy += Destroy;
    }
    
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
