using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cartridges;
    [SerializeField] private Target _target;
    [SerializeField] private PlayerShoot _shoot;
    [SerializeField] private Counter _counter;

    private void Update()
    {
        _cartridges.text = "Оставшиеся патроны: " + _shoot.CurrentCanon.Ammo;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            _counter.AddCount();
            _shoot.CurrentCanon.ChangeTarget(_target);
            Destroy(collision.gameObject);
        }
    }
}
