using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Ball : MonoBehaviour {
    [field: SerializeField] public float Damage { get; private set; }
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public void Fly(Vector3 direction, float force) 
    {
        _rigidbody.AddForce(direction * force, ForceMode.Impulse);
    }
}
