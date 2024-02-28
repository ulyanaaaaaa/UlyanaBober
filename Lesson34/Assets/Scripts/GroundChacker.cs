using UnityEngine;

public class GroundChacker : MonoBehaviour
{
    [SerializeField] public bool IsGround = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            IsGround = true;
        }
        else
        {
            IsGround = false;
        }
    }
}
