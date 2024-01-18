using UnityEngine;
public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    private float _speed;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Fly(Vector3 direction, float force)
    {
        _rigidbody.AddForce(direction * force, ForceMode.Impulse);
    }
}
