using Unity.VisualScripting;
using UnityEngine;

public class SpeededBird : Bird
{
    [SerializeField] private int _force;


    private void OnMouseUp()
    {
        _rigidbody.AddForce(_rigidbody.velocity * _force, ForceMode2D.Impulse);
    }
}
