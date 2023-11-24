using UnityEngine;

public class BirdsFactory : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    public Bird CreateBird(Vector2 position) 
    {
        Bird birdCreated = Instantiate(_bird, position, Quaternion.identity);
        return birdCreated;
    }
}
