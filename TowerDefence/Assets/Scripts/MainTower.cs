using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Wallet))]
public class MainTower : Tower
{
   private void Awake()
   {
      _wallet = GetComponent<Wallet>();
   }
}
