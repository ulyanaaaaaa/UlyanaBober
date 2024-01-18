using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Action OnDie;

    [SerializeField] private float _maxHealth;
    [SerializeField] private BonusTimer _bonusTimer;
    [SerializeField] private BasicBonus _basicBonus;
    [SerializeField] private SizeBonus _sizeBonus;
    [SerializeField] private SpeedBonus _speedBonus;
    
    public  bool IsTookBasicBonus { get; private set; }
    public  bool IsTookSpeedBonus { get; private set; }
    public  bool IsTookSizeBonus { get; private set; }

    private float _health;
    private Coroutine _basicBonusTick;
    private Coroutine _speedBonusTick;
    private Coroutine _sizeBonusTick;
    
    private float _secondsDone;

    private void Awake()
    {
        _health = _maxHealth;
        _bonusTimer = GetComponent<BonusTimer>();
        _basicBonus = GetComponent<BasicBonus>();
        _sizeBonus = GetComponent<SizeBonus>();
        _speedBonus = GetComponent<SpeedBonus>();
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
    
    private IEnumerator BasicBonusTick(float time)
    {
        while (_secondsDone < time)
        {
            Debug.Log("ddd");
            _bonusTimer.TimerText.text = (time - _secondsDone).ToString();
            yield return new WaitForSeconds(1);
            _secondsDone++;
        }
        IsTookBasicBonus = false;
    }
    
    private IEnumerator SpeedBonusTick(float time)
    {
        while (_secondsDone < time)
        {
            Debug.Log("ddd");
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
            Debug.Log("ddd");
            _bonusTimer.TimerText.text = (time - _secondsDone).ToString();
            yield return new WaitForSeconds(1);
            _secondsDone++;
        }
        IsTookSizeBonus = false;
    }
}
