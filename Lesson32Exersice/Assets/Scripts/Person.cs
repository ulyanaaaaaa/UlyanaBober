using System.Collections;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _delay;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private Person _person;
    private Vector3 _position;

    private void Awake()
    {
        StartCoroutine(HitTick());
    }

    private IEnumerator HitTick()
    {
        Hit();
        yield return new WaitForSeconds(_delay);
    }

    private void Hit()
    {
        _person._health -= _damage;
        if (_person._health <= 0)
        {
            Die();
            _person = CreateNewPerson();
        }
    }

    private void Die()
    {
        _position = _person.transform.position;
        Destroy(_person.gameObject);
    }

    private Person CreateNewPerson()
    {
        _health = _maxHealth;
        return Instantiate(_person, _position, Quaternion.identity);
    }
}
