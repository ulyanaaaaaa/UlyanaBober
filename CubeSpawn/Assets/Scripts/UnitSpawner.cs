using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    private UnitFabrica _fabrica;
    private List<Unit> _units = new List<Unit>();
    private Coroutine _moveTick;

    private void Awake()
    {
        _fabrica = GetComponent<UnitFabrica>();
    }

    private void Start()
    {
        NewUnits();
    }

    private void Update()
    {  

        if (Input.GetKeyDown(KeyCode.W))
        {
            _moveTick = StartCoroutine(MoveTick());
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (_moveTick != null)
            {
                StopCoroutine(_moveTick);
                _moveTick = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            NewUnits();
        }
    }

    private void NewUnits()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 randomPosition = transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            _units.Add(_fabrica.CreateUnit(randomPosition, transform));
        }
    }

    private IEnumerator MoveTick()
    {
        for(int i= 0;i < _units.Count;i++)
        {
            yield return new WaitForSeconds(Random.Range(0,4));
            _units[i].Move(Vector3.left);
        }
    }
}
