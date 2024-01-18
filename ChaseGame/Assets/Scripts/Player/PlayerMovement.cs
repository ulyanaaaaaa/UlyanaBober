using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _animator;
    //private float _velocity;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private bool _isGround;
    [SerializeField] private GroundCheker _groundCheker;
    [SerializeField] private PlayerHealth _playerHealth;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _groundCheker.OnEnter += SetGround;
        _groundCheker.OnExit += RemoveGround;
        _animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void SetGround()
    {
        _isGround = true;
    }

    private void RemoveGround()
    {
        _isGround = false;
    }

    private void Update()
    {
        RotateCamera();
        Movement();

        if(Input.GetKey(KeyCode.Space)) {
            Jump(); 
        }

        if (_playerHealth.IsTookSizeBonus)
        {
            _player.transform.localScale *= 1.0002f;
        }
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * _rotateSpeed;
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
    }

    private void Movement()
    {
        Vector3 inputMove = Vector3.zero;

        inputMove.x = Input.GetAxis("Horizontal");
        inputMove.z = Input.GetAxis("Vertical");
        
        if (!_playerHealth.IsTookSpeedBonus)
            inputMove *= _speed;
        else
            inputMove = inputMove * _speed * 2;

        Vector3 directionMove = transform.right * inputMove.x + transform.forward * inputMove.z;

        _rigidbody.velocity = new Vector3(directionMove.x, _rigidbody.velocity.y, directionMove.z);
        
        //_animator.SetFloat("Velocity" , directio);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpHeight, ForceMode.Impulse);
    }
}
