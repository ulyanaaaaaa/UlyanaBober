using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] public float Damage;
    
    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("1");
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Debug.Log("2");
            Destroy(gameObject);
        }
    }
}
