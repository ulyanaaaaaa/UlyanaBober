using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [field: SerializeField] public BallType Type { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject);
    }

    public void Fly(Vector3 direction, float force) 
    {
        _rigidbody.AddForce(direction * force, ForceMode.Impulse);
    }
}
