using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
   private Player _player;
   private Enemy _enemy;

   private void Awake()
   {
      _enemy = GetComponent<Enemy>();
   }
   
   public IEnumerator TimerTick()
   {
      Debug.Log("1");
      yield return new WaitForSeconds(3);
      _enemy.SetRandomHand();
      Debug.Log("3");
      
   }
}
