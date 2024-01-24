using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private Vector3 _moveDirection, _moveVector;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        RotateCamera();
        Hit();
        Jump();
    }

    private void Move()
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _moveVector.z = Input.GetAxis("Vertical");
        
        _moveDirection = new Vector3(_moveVector.x, 0, _moveVector.z);
        _rigidbody.MovePosition(_rigidbody.position + _moveDirection * _speed * Time.deltaTime );

        _animator.SetBool("IsRun", (_moveVector.x +_moveVector.z > 0) || (_moveVector.x + _moveVector.z < 0));
    }

    private void Hit()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Animator>().SetBool("IsHit", !GetComponent<Animator>().GetBool("IsHit"));
        }
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _animator.SetBool("IsJump", true);
        }
    }
    
    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * _rotateSpeed;
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
    }

}
