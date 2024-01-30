using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public int Id;

    private void Awake() => Id = Random.Range(0, 1000);

    public void Die() => Destroy(this.gameObject);
    
}
