using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    private const float Gravity = 9.81f;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private CharacterController _controller;
    private Vector3 _direction;
    private Vector3 _velocity;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private bool _isGround;
    [SerializeField] private GroundCheker _groundCheker;
    [SerializeField] private PlayerHealth _playerHealth;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _groundCheker.OnEnter += SetGround;
        _groundCheker.OnExit += RemoveGround;
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
        if (_controller.isGrounded)
        {
            _direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _animator.SetFloat("Velocity", _direction.z + _direction.x + _direction.z);

            if (_playerHealth.IsTookSpeedBonus)
                _direction *= 2;

            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
        }
        _controller.Move(_direction * Time.deltaTime * _speed);
    }

    private void Jump()
    {
        _velocity.y += Mathf.Sqrt(_jumpHeight * -2f * Gravity);
    }
}
