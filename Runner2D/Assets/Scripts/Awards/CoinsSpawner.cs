using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CoinsFabrica))]

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    private CoinsFabrica _coinsFabrica;
    private Coroutine _spawnTick;

    private void Awake()
    {
        _coinsFabrica = GetComponent<CoinsFabrica>();
    }

    private void Start()
    {
        _spawnTick = StartCoroutine(SpawnTick());
    }

    private void CreateCoin()
    {
        _coinsFabrica.CreateCoin();
    }

    private IEnumerator SpawnTick()
    {
        while (true)
        {
            CreateCoin();
            yield return new WaitForSeconds(_delay);
        }
    }
}
