using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class Unit : MonoBehaviour
{
    [SerializeField] private float _speed;   
    [SerializeField] private Material _newMaterial;

    private MeshRenderer _meshRenderer;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(Random.Range(2, 5));
        _meshRenderer.material = _newMaterial;
    }

    public void Move(Vector2 direction)
    {
        _rigidbody.AddForce (direction * _speed, ForceMode.Impulse);
    }
}
