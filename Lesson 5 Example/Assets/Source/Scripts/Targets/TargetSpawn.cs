using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    [SerializeField] private float _count;
    [SerializeField] private Target _target;

    private void Awake()
    {
        for (int i = 0; i < _count; i++)
        {
            Instantiate(_target, (Vector2)transform.position + new Vector2(Random.Range(-5, 5), Random.Range(0, 5)), Quaternion.identity);
        }
    }
}
