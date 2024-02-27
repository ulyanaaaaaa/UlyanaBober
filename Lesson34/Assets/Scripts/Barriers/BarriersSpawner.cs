using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BarriersFabrica))]
public class BarriersSpawner : MonoBehaviour
{
    public List<Barrier> Barriers;
    [SerializeField] private float _delay;
    private BarriersFabrica _barriersFabrica;
    private Coroutine _spawnTick;
    
    private void Awake()
    {
        _barriersFabrica = GetComponent<BarriersFabrica>();
    }

    private void Start()
    {
        _spawnTick = StartCoroutine(SpawnTick());
    }

    private void CreateBarrier()
    {
        int random = Random.Range(0, 100);

        if (random <= 50)
        {
            Barriers.Add(_barriersFabrica.CreateHitBarrier());
        }
        else
        {
            Barriers.Add(_barriersFabrica.CreateJumpBarrier());
        }
    }

    private IEnumerator SpawnTick()
    {
        while (true)
        {
            CreateBarrier();
            yield return new WaitForSeconds(_delay);
        }
    }
}
