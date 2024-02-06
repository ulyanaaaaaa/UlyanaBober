using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private List<Resource> _workResources = new List<Resource>();

    public void AddWorkResources(List<Resource> resources)
    {
        _workResources.AddRange(resources);
        resources.Clear();
    }
}
