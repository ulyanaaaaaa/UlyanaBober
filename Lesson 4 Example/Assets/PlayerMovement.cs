using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _firstLetter, _secondLetter;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _jumpCount;
    [SerializeField] private float _speed;
    [SerializeField] private Mass _mass;
    [SerializeField] private Vector3 _vector;

    private void Start()
    {
 
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            _rigidbody.velocity = new Vector3(0, 0, _speed);
            _rigidbody.AddForce(new Vector3(0,500,0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.velocity = new Vector3(0, 0, -_speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.velocity = new Vector3(-_speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.velocity = new Vector3(_speed, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Mass>())
        {
            if(_mass.Amount > collision.gameObject.GetComponent<Mass>().Amount) 
            {
                _mass.Amount += collision.gameObject.GetComponent<Mass>().Amount;
                transform.localScale = new Vector3(_mass.Amount, _mass.Amount, _mass.Amount);
                Destroy(collision.gameObject);
            }
        }
    }
}
