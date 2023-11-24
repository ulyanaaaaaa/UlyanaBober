using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private TextMeshProUGUI _counter;

    private protected virtual void Hit(Ball ball) 
    {
        if (ball.Type == BallType.Simple)
            _count++;
        if (ball.Type == BallType.Big)
            _count += 2;

        _counter.text = "Count: " + _count.ToString();
        Destroy(ball.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball)) 
        {
            Hit(ball);
        }
    }
}
