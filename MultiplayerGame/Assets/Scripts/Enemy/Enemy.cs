using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Enemy : MonoBehaviour, IHit
{
   [SerializeField] private protected float _health;
   [SerializeField] private protected float _force;
   [SerializeField] private protected float _speed;
   [SerializeField] private protected float _delay;
   private Rigidbody _rigidbody;
   private Player _player;
   private Coroutine _hitTick;

   private void Awake()
   {
      _rigidbody = GetComponent<Rigidbody>();
   }

   private void Start()
   {
      _hitTick = StartCoroutine(HitTick());
   }

   private void Update()
   {
      _rigidbody.velocity = (_player.transform.position - transform.position).normalized * _speed;

      if (_health <= 0)
         Die();
   }
   
   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.TryGetComponent(out Ball ball))
      {
         _health -= ball.Damage;
      }
   }

   public virtual void Hit()
   {
      SmallBall ball = Instantiate(Resources.Load<SmallBall>("SmallBall"), transform.position, Quaternion.identity);
      ball.Fly(transform.forward, _force);
   }

   public void Setup(Player player)
   {
      _player = player;
   }

   private void Die()
   {
      Destroy(gameObject);
   }

   private IEnumerator HitTick()
   {
      while (true)
      {
         Hit();
         yield return new WaitForSeconds(_delay);
      }
   }
}
