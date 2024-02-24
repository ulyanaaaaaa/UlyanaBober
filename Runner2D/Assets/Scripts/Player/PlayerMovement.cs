using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float minY = -3.5f, maxY = 3.5f;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        Move();
        if (Input.GetKey(KeyCode.W))
            _rigidbody.velocity = Vector2.up * _speed;

        if (Input.GetKey(KeyCode.S))
            _rigidbody.velocity = Vector2.down * _speed;
        
        if(!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            _rigidbody.velocity = Vector2.zero;
        
    }

    private void Move()
    {
        transform.position = new Vector2(transform.position.x, Math.Clamp(transform.position.y, minY, maxY));
    }
}
