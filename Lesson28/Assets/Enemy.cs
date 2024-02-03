using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Color Color;
    public float Health;

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    private void Awake()
    {
        int chance = Random.Range(0, 100);
        
        if(chance < 25)
            Color = Color.black;
        if(chance >=  25 && chance > 50)
            Color = Color.red;
        if(chance >= 50 && chance < 75)
            Color = Color.green;
        if(chance >= 75 )
            Color = Color.blue;

        Health = Random.Range(50, 500);
    }
}
