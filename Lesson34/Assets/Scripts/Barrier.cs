using UnityEngine;

public class Barrier : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int health)
    {
        health--;
        Destroy();
    }
}
