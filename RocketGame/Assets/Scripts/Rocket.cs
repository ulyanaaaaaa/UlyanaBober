using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rocket : MonoBehaviour
{
    public Action OnDie;
    
    [field: SerializeField] public float Fuel { get; private set; } = 100;
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;
    [SerializeField] private KeabordInput _input;
    private Coroutine _fuelTick;
    [field: SerializeField] public int Wallet { get; private set; }
    private bool _isPlay;

    private void Start()
    {
        Load();
        _rigidbody = GetComponent<Rigidbody>();
        _input.OnLeftClicked += TurnLeft;
        _input.OnRightClicked += TurnRight;
        _input.OnPlay += StartCoroutine;
    }

    public void Setup(KeabordInput input)
    {
        _input = input;
    }

    private void Update()
    {
        if(_isPlay)
            _rigidbody.velocity = Vector3.up * _speed;
    }

    private void StartCoroutine()
    {
        _isPlay = true;
        _fuelTick = StartCoroutine(FuelTick());
    }
    
    private void TurnLeft()
    {
        _rigidbody.velocity = Vector3.left * _speed;
    }
    
    private void TurnRight()
    {
        _rigidbody.velocity = Vector3.right * _speed;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Money money))
        {
            Wallet += money.Resources;
        }
        
        if (collider.gameObject.TryGetComponent(out Fuel fuel))
        {
            Fuel += 30;
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Wallet", Wallet);
        PlayerPrefs.SetFloat("Speed", _speed);
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey("Wallet"))
            Wallet = PlayerPrefs.GetInt("Wallet", Wallet);

        if (PlayerPrefs.HasKey("Speed"))
            _speed = PlayerPrefs.GetFloat("Speed", _speed);
    }
    
    private void RemoveValue(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Value must be positive!");
        
        Wallet-= amount;
    }

    public void AddSpeed(float speed)
    {
        _speed += speed;
    }

    public bool TrySpend(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Value must be positive!");

        if (amount > Wallet)
        {
            return false;
        }
        else
        {
            RemoveValue(amount);
            return true;
        }
    }

    private IEnumerator FuelTick()
    {
        while (true)
        {
            Fuel--;
            yield return new WaitForSeconds(1);

            if (Fuel == 0)
            {
                Save();
                OnDie?.Invoke();
                break;
            }
        }
    }
}