using UnityEngine;

[RequireComponent(typeof(AudioListener))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Move()
    {
        float inputMoveX = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(inputMoveX * _speed, _rigidbody.velocity.y);
    }
    
    private void Jump() => _rigidbody.velocity = new Vector2( 0, _jumpSpeed);

}
