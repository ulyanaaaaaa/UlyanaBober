using UnityEngine;
using System.Collections;

public class TargetSpawn : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private float _randomX;
    [SerializeField] private float _randomY;
    [SerializeField] private float _randomZ;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _coroutineDelay;
    private Vector3 _spawnPoint;

    private IEnumerator CreateTarget()
    {
        yield return new WaitForSeconds(_spawnDelay);
        _randomX = Random.Range(-15, 22);
        _randomY = Random.Range(0, 8);
        _randomZ = Random.Range(0.2f, 4);
        _spawnPoint = new Vector3(_randomX, _randomY, _randomZ);
        Target targetCreate = Instantiate(_target, _spawnPoint, Quaternion.identity).GetComponent<Target>();
        targetCreate.GetComponent<Renderer>().material.color = Color.yellow;
        StartCoroutine(CreateTarget());
    }

    private void Start()
    {
        StartCoroutine(CreateTarget());
    }
}
