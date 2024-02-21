using System.Collections;
using UnityEngine;

public class BoxFactory : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Player _player;
    private Coroutine _spawnBoxTick;

    private void Start()
    {
        Debug.Log("fds");
        _spawnBoxTick = StartCoroutine(SpawnBoxTick());
    }
    
    private IEnumerator SpawnBoxTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            Instantiate(Resources.Load<Box>("Box"),
                new Vector3(Random.Range(-5, 18), 0.68f, -3.40f), 
                Quaternion.identity).Setup(_player);
        }
    }
}
