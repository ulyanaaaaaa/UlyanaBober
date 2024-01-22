using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private Vector3 movedirection;

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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        movedirection = new Vector3(moveHorizontal , 0 ,moveVertical);

        transform.Translate(movedirection * _speed * Time.deltaTime);
        
        _animator.SetBool("IsRun", (moveHorizontal + moveVertical > 0) || (moveHorizontal + moveVertical < 0));
    }

    private void Hit()
    {
        if (Input.GetKey(KeyCode.E))
        {
            _animator.SetBool("IsHit", true);
        }
        else
        {
            _animator.SetBool("IsHit", false);
        }
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _animator.SetBool("IsJump", true);
        }
        else
        {
            _animator.SetBool("IsJump", false);
        }
    }
    
    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * _rotateSpeed;
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
    }

}
