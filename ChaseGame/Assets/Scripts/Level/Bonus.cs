using UnityEngine;

public class Bonus : MonoBehaviour, IEntryPointSetupBonusTimer
{
    [field: SerializeField] public float Time { get; private set; }
    private Transform _bonusTimer;
    
    public void Destroy() => Destroy(gameObject);

    public void Setup(BonusTimer bonusTimer)
    {
        _bonusTimer = bonusTimer.transform;
    }
}
