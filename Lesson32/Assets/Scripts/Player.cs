using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;
    public float Health { get; private set; } = 10;

    private IInput _input = new InputAxis();

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Setup(IInput input)
    {
        _input = input;
    }

    private void Update()
    {
        _rigidbody.velocity = _input.Direction;
    }
}

public interface IInput
{
    Vector3 Direction { get; }
}

public class InputAxis : IInput
{
    public Vector3 Direction => new Vector3(Input.GetAxis("Horizontal"),0 ,Input.GetAxis("Vertical"));
}
