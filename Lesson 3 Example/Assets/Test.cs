using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private string _name;

    void Start()
    {

    }

    public void TakeDamage(int damage)
    {

        _health -= damage;
        Debug.Log(_health);
    }
}
