using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _force;
    [field: SerializeField] public float Damage { get; private set; }
    
    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Destroy(gameObject);
        }
    }
}
