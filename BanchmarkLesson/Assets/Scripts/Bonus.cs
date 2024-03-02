using UnityEngine;

public class Bonus : MonoBehaviour
{
    [field: SerializeField] public float Time { get; private set; }
    private Transform _bonusTimer;
    
    public void Destroy() => Destroy(gameObject);
}
