using System.Collections;
using UnityEngine;

public class Person : MonoBehaviour
{
    [field: SerializeField] public float Health { get; private set;}
    [SerializeField] private float _delay;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] public Person EnemyPerson;
    private Vector3 _position;

    private void Awake()
    {
        StartCoroutine(HitTick());
    }

    private IEnumerator HitTick()
    {
        while (true)
        {
            if (EnemyPerson)
                Hit(_damage);
            
            yield return new WaitForSeconds(_delay);
        }
    }

    public void Hit(float damage)
    {
        EnemyPerson.Health -= damage;
        if (EnemyPerson.Health <= 0)
        {
            Health = _maxHealth;
            Die();
            StartCoroutine(RespawnTick());
        }
    }

    private IEnumerator RespawnTick()
    {
        yield return new WaitForSeconds(1);
        Person newPerson = CreateNewPerson();
        newPerson.EnemyPerson = this;
        EnemyPerson = newPerson;
    }

    private void Die()
    {
        _position = EnemyPerson.transform.position;
        Destroy(EnemyPerson.gameObject);
    }

    private Person CreateNewPerson()
    {
        return Instantiate(Resources.Load<Person>("RedPerson"), _position, Quaternion.identity);
    }
}
