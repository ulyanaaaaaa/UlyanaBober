using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rocket : MonoBehaviour
{
    public Action OnDie;

    [SerializeField] private float _maxFuel = 100;
    [field: SerializeField] public float Fuel { get; private set; }
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;
    [SerializeField] private KeabordInput _input;
    private Coroutine _fuelTick;
    private MoneyCounter _moneyCounter;
    [field: SerializeField] public int Wallet { get; private set; }
    private bool _isPlay;

    private void Start()
    {
        Load();
        _moneyCounter.CurrentMoney(Wallet);
        Fuel = _maxFuel;
        _rigidbody = GetComponent<Rigidbody>();
        _input.OnLeftClicked += TurnLeft;
        _input.OnRightClicked += TurnRight;
        _input.OnPlay += StartCoroutine;
    }

    public void Setup(KeabordInput input, MoneyCounter moneyCounter)
    {
        _input = input;
        _moneyCounter = moneyCounter;
    }

    private void Update()
    {
        if (_isPlay)
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
            _moneyCounter.CurrentMoney(Wallet);
        }
        
        if (collider.gameObject.TryGetComponent(out Fuel fuel))
        {
            Fuel += fuel.Count;
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Wallet", Wallet);
        PlayerPrefs.SetFloat("Speed", _speed);
        PlayerPrefs.SetFloat("MaxFuel", _maxFuel);
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey("Wallet"))
            Wallet = PlayerPrefs.GetInt("Wallet", Wallet);

        if (PlayerPrefs.HasKey("Speed"))
            _speed = PlayerPrefs.GetFloat("Speed", _speed);
        
        if (PlayerPrefs.HasKey("MaxFuel"))
            _maxFuel = PlayerPrefs.GetFloat("MaxFuel", _maxFuel);
    }
    
    private void RemoveValue(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Value must be positive!");
        
        Wallet -= amount;
        _moneyCounter.CurrentMoney(Wallet);
    }

    public void AddSpeed(float speed)
    {
        _speed += speed;
    }

    public void AddFuel(float fuel)
    {
        _maxFuel += fuel;
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