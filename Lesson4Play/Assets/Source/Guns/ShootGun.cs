using UnityEngine;

class ShootGun : IShootGun
{
    public void Visit(Gun hit)
    {
        Debug.Log("Gun hit!");
    }

    public void Visit(BigGun hit)
    {
        Debug.Log("Big gun hit!");
    }
}

abstract class Hit : MonoBehaviour
{
    public abstract void Accept(IShootGun visiter);
}
