using UnityEngine;

public class Test2 : MonoBehaviour
{
    [SerializeField] private Test test;

    private void Start()
    {
        test.TakeDamage(5);
    }
}
