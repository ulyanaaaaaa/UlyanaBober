using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Worker : MonoBehaviour
{
    [SerializeField] private List<Factory> _factories = new List<Factory>();
    [SerializeField] private List<Resource> _newResources = new List<Resource>();
    [SerializeField] private Storage _storage;

    private Coroutine _newResourcesTick;

    private void Start() =>
        _newResourcesTick = StartCoroutine(NewResourcesTick());
    
    
    private IEnumerator NewResourcesTick()
    {
        while (true)
        {
            foreach (Factory factory in _factories)
            {
                yield return new WaitForSeconds(5);
                transform.DOMove(factory.transform.position, 1);
                yield return new WaitForSeconds(1);
                
                if (Vector3.Distance(factory.transform.position, transform.position) < 1)
                {
                    _newResources.AddRange(factory.Resources);
                    factory.Resources.Clear();
                }
            }
            
            transform.DOMove(_storage.transform.position, 1);
            yield return new WaitForSeconds(1);
            
            if (Vector3.Distance(_storage.transform.position, transform.position) < 1)
                _storage.AddWorkResources(_newResources);
        }
    }
}
