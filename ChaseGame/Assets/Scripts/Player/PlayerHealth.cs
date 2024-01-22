using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IEntryPointSetupBonusTimer
{
    public Action OnDie;
    
    [SerializeField] private float _maxHealth;
    [SerializeField] private BonusTimer _bonusTimer;
    [SerializeField] private BasicBonus _basicBonus;
    [SerializeField] private SizeBonus _sizeBonus;
    [SerializeField] private SpeedBonus _speedBonus;
    [SerializeField] private Enemy _enemy;
    
    public  bool IsTookBasicBonus { get; private set; }
    public  bool IsTookSpeedBonus { get; private set; }
    public  bool IsTookSizeBonus { get; private set; }

    private float _health;
    private Animator _animator;
    private Coroutine _basicBonusTick;
    private Coroutine _speedBonusTick;
    private Coroutine _sizeBonusTick;
    
    private float _secondsDone;

    private void Awake()
    {
        _health = _maxHealth;
        _animator = GetComponent<Animator>();
        _bonusTimer = GetComponent<BonusTimer>();
        _basicBonus = GetComponent<BasicBonus>();
        _sizeBonus = GetComponent<SizeBonus>();
        _speedBonus = GetComponent<SpeedBonus>();
        _enemy = GetComponent<Enemy>();
        _enemy.OnHit += HitOff;
    }
    
    public void Setup(BonusTimer bonusTimer)
    {
        _bonusTimer = bonusTimer;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentException("Damage must be positive!");
        
        _health -= damage;
        
        if (_health < 0)
            OnDie?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out BasicBonus bonus))
        {
            if(IsTookBasicBonus) 
                return;
            IsTookBasicBonus = true;
            _basicBonusTick = StartCoroutine(BasicBonusTick(bonus.Time));
            bonus.Destroy();
        }

        if (other.transform.TryGetComponent(out SpeedBonus speedBonus))
        {
            if(IsTookSpeedBonus)
                return;
            IsTookSpeedBonus = true;
            _speedBonusTick = StartCoroutine(SpeedBonusTick(speedBonus.Time));
            speedBonus.Destroy();
        }
        
        if (other.transform.TryGetComponent(out SizeBonus sizeBonus))
        {
            if(IsTookSizeBonus)
                return;
            IsTookSizeBonus = true;
            _sizeBonusTick = StartCoroutine(SizeBonusTick(sizeBonus.Time));
            sizeBonus.Destroy();
        }
        
    }

    public void HitOn()
    {
        Debug.Log("Hit");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Hit");
            _animator.SetFloat("Hit", -1);
        }
    }

    public void HitOff()
    {
        _animator.SetFloat("Hit", 1);
    }
    
    private IEnumerator BasicBonusTick(float time)
    {
        _enemy.OnHit -= HitOff;
        _enemy.OnHit += HitOn;
        
        while (_secondsDone < time)
        {
            _bonusTimer.TimerText.text = (time - _secondsDone).ToString();
            yield return new WaitForSeconds(1);
            _secondsDone++;
        }
        
        IsTookBasicBonus = false;
        
        _enemy.OnHit += HitOff;
        _enemy.OnHit -= HitOn;
    }
    
    private IEnumerator SpeedBonusTick(float time)
    {
        while (_secondsDone < time)
        {
            yield return new WaitForSeconds(1);
            _bonusTimer.TimerText.text = (time - _secondsDone).ToString();
            _secondsDone++;
        }
        IsTookSpeedBonus = false;
    }

    private IEnumerator SizeBonusTick(float time)
    {
        
        while (_secondsDone < time)
        {
            _bonusTimer.TimerText.text = (time - _secondsDone).ToString();
            yield return new WaitForSeconds(1);
            _secondsDone++;
        }
        IsTookSizeBonus = false;
    }
}
