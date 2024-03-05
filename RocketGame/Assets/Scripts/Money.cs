using UnityEngine;

public class Money : MonoBehaviour
{
    [field: SerializeField] public int Resources { get; private set; }

    private void Start()
    {
        Resources = (int)transform.position.y;
    }
}
