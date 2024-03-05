using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rocket : MonoBehaviour
{
    public Action OnDie;
    
    [field: SerializeField] public float Fuel { get; private set; } = 100;
    
    [SerializeField] private List<int> _wallet;
    
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;
    [SerializeField] private KeabordInput _input;
    private Coroutine _fuelTick;
    [SerializeField] private int _wholeMoney;
    private bool _isPlay;

    private void Start()
    {
        LoadMoney();
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
            _wallet.Add(money.Resources);
        }
        
        if (collider.gameObject.TryGetComponent(out Fuel fuel))
        {
            Fuel += 30;
        }
    }

    private void SaveMoney()
    {
        foreach (int count in _wallet)
            _wholeMoney += count;
        
        PlayerPrefs.SetInt("Wallet", _wholeMoney);
    }

    private void LoadMoney()
    {
        if (PlayerPrefs.HasKey("Wallet"))
            _wholeMoney = PlayerPrefs.GetInt("Wallet", _wholeMoney);
    }

    private IEnumerator FuelTick()
    {
        while (true)
        {
            Fuel--;
            yield return new WaitForSeconds(1);

            if (Fuel == 0)
            {
                SaveMoney();
                OnDie?.Invoke();
                break;
            }
        }
    }
}