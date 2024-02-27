using UnityEngine;

public class BarriersFabrica : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    private HitBarrier _hitBarrier;
    private BarriersSpawner _spawner;
    private JumpBarrier _jumpBarrier;

    private void Awake()
    {
        _hitBarrier = Resources.Load<HitBarrier>("HitBarrier");
        _jumpBarrier = Resources.Load<JumpBarrier>("JumpBarrier");
        _spawner = GetComponent<BarriersSpawner>();
    }

    public Barrier CreateHitBarrier()
    {
        return Instantiate(_hitBarrier, _spawnPoint.position, Quaternion.identity).Setup(_spawner);
    }
    
    public Barrier CreateJumpBarrier()
    {
        return Instantiate(_jumpBarrier, _spawnPoint.position, Quaternion.identity).Setup(_spawner);
    }
}
                                                                                                                                                                                                                                                                                                                                