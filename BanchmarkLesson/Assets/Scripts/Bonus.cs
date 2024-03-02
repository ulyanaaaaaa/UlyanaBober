using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bonus : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private float _speed;
    private Coroutine _slowlyEnemyTick;
    private Rigidbody2D _rigidbody;
    private Player _player;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Setup(Player player)
    {
        _player = player;
    }

    private void Update()
    {
        _rigidbody.velocity = Vector2.down * _speed;
    }

    public void Timer()
    {
        _slowlyEnemyTick = StartCoroutine(TimerTick());
    }

    private IEnumerator TimerTick()
    {
        float currentTime = 0;
        while (currentTime <= _time)
        {
            currentTime++;
            yield return new WaitForSeconds(1);
        }

        _player.IsTookBonus = false;
        Destroy(gameObject);
    }
}
