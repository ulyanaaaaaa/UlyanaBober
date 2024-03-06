using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rocket : MonoBehaviour
{
    public Action OnDie;

    [field: SerializeField] public float MaxFuel { get; private set; } = 100;
    [field: SerializeField] public float Fuel { get; private set; }
    public int Wallet { get; private set; }
    
    private float _speed;
    private Rigidbody _rigidbody;
    private KeabordInput _input;
    private Coroutine _fuelTick;
    private MoneyCounter _moneyCounter;
    private bool _isPlay;
    
    public void Setup(KeabordInput input, MoneyCounter moneyCounter)
    {
        _input = input;
        _moneyCounter = moneyCounter;
    }

    private void Start()
    {
        Load();
        Fuel = MaxFuel;
        _moneyCounter.CurrentMoney(Wallet);
        _rigidbody = GetComponent<Rigidbody>();
        _input.OnPlay += StartPlay;
    }

    private void Update()
    {
        if (_isPlay)
            _rigidbody.velocity = Vector3.up * _speed;
    }
    
    public void AddSpeed(float speed)
    {
        _speed += speed;
    }

    public void AddFuel(float fuel)
    {
        MaxFuel += fuel;
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

    private void StartPlay()
    {
        _input.OnLeftClicked += TurnLeft;
        _input.OnRightClicked += TurnRight;
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
    
    private void Save()
    {
        PlayerPrefs.SetInt("Wallet", Wallet);
        PlayerPrefs.SetFloat("Speed", _speed);
        PlayerPrefs.SetFloat("MaxFuel", MaxFuel);
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey("Wallet"))
            Wallet = PlayerPrefs.GetInt("Wallet", Wallet);

        if (PlayerPrefs.HasKey("Speed"))
            _speed = PlayerPrefs.GetFloat("Speed", _speed);
        
        if (PlayerPrefs.HasKey("MaxFuel"))
            MaxFuel = PlayerPrefs.GetFloat("MaxFuel", MaxFuel);
    }
    
    private void RemoveValue(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Value must be positive!");
        
        Wallet -= amount;
        _moneyCounter.CurrentMoney(Wallet);
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