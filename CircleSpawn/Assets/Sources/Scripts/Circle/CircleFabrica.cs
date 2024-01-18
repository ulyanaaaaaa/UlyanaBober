using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFabrica : MonoBehaviour
{
    [SerializeField] Circle _circle;

    public Circle CreateCircle(Vector3 position)
    {
        return Instantiate(_circle ,position, Quaternion.Euler(new Vector3(-90, 0, 0))).SetColor(Color.black).SetCount(1).SetLifeTime(6);
    }

    public Circle CreateMoveCircle(Vector3 position)
    {
        return Instantiate(_circle, position, Quaternion.Euler(new Vector3(-90, 0, 0))).SetMoveType().SetColor(Color.green).SetCount(2).SetLifeTime(4);
    }

    public Circle CreateLifeTimeCircle(Vector3 position)
    {
        return Instantiate(_circle, position, Quaternion.Euler(new Vector3(-90, 0, 0))).SetColor(Color.red).SetLifeTime(2).SetCount(3);
    }

    public Circle CreateDangerCircle(Vector3 position)
    {
        return Instantiate(_circle, position, Quaternion.Euler(new Vector3(-90, 0, 0))).SetColor(Color.yellow).SetLifeTime(10);
    }
}
