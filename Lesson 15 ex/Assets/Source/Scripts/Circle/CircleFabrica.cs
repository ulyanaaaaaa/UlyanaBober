using UnityEngine;

public class CircleFabrica : MonoBehaviour
{
    [SerializeField] private Circle _circle;

    public Circle CreateCircle(Vector3 position) 
    {
        return Instantiate(_circle, position, Quaternion.Euler(new Vector3(-90,0,0))).SetColor(Color.white);
    } 
    
    public Circle CreateMoveCircle(Vector3 position) 
    {
        return Instantiate(_circle, position, Quaternion.Euler(new Vector3(-90,0,0))).SetMoveType().SetColor(Color.green);
    }

    public Circle CreateBadCircle(Vector3 position)
    {
        return Instantiate(_circle, position, Quaternion.Euler(new Vector3(-90, 0, 0))).SetColor(Color.red).SetLifetime(25);
    }
    public Circle CreateGoldCircle(Vector3 position)
    {
        return Instantiate(_circle, position, Quaternion.Euler(new Vector3(-90, 0, 0))).SetColor(Color.yellow).SetLifetime(2).SetScore(5);
    }
}
