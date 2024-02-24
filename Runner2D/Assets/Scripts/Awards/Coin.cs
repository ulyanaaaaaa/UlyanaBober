using System;
using UnityEngine;

public class Coin : MonoBehaviour
{ 
    public Action OnDestroy;
    [SerializeField] private float _speed;

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
