using UnityEngine;

[RequireComponent(typeof(CubeSpawner))]
public class CubeFabrica : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    private CubeSpawner _cubeSpawner;

    private void Awake()
    {
        _cubeSpawner = GetComponent<CubeSpawner>();
    }

    private void Start()
    {
        
        CreateRandomCube();
    }
    public void CreateRandomCube()
    {
        int random = Random.Range(0, 100);
        
        if (random > 50)
            _cubeSpawner.CreateRedCube(_spawnPosition.position);
        else
            _cubeSpawner.CreateYellowCube(_spawnPosition.position);
    }
}
