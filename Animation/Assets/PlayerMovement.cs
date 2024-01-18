using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    
    private Rigidbody _rigidbody;
    private Animator _animator;

    private float _velocity;
    private Vector3 _inputMove;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            _velocity += (1 * _speed) * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            _velocity -= (1 * _speed) * Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X") * _rotateSpeed;

        transform.rotation *= Quaternion.Euler(0, mouseX, 0);

        _velocity = Math.Clamp(_velocity, -1, 1);
        
        _animator.SetFloat("Velocity" , _velocity);
        
        _rigidbody.velocity = ((transform.rotation * Vector3.forward) * _speed) * _velocity;
    }
}
