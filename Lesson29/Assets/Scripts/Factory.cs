using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] public List<Resource> Resources = new List<Resource>();

    private Coroutine _addResources;

    private void Start() =>
        _addResources = StartCoroutine(AddResourcesTick());

    private IEnumerator AddResourcesTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Resources.Add(new Resource());
        }
    }
}
