using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public Cube CreateYellowCube(Vector3 position)
    {
        Cube newCube = Resources.Load<Cube>("2");
        return Instantiate(newCube, position, Quaternion.identity);
    }
    
    public Cube CreateRedCube(Vector3 position)
    {
        Cube newCube = Resources.Load<Cube>("4");
        return Instantiate(newCube, position, Quaternion.identity);
    }
}
