using UnityEngine;

[RequireComponent(typeof(CubeSpawner))]
public class CubeFabrica : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPosition;
    private CubeSpawner _cubeSpawner;
    
    public void CreateRandomCube()
    {
        int random = Random.Range(0, 100);
        
        if (random > 50)
            _cubeSpawner.CreateRedCube(_spawnPosition);
        else
            _cubeSpawner.CreateYellowCube(_spawnPosition);
    }
}
