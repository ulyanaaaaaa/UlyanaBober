using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum EnemyColors
{
    Red,
    Green,
    Black,
    Blue,
    White
}

public class Enemy : MonoBehaviour, ISaveData
{
    [SerializeField] private int _health;
    [SerializeField] private SaveService _saveService;
    
    private EnemyColors _type;
    private Transform _enemy;

    [field: SerializeField] public string Id { get; set; } = "";

    private void Start()
    {
        if (Id == "")
            Id = Random.Range(0, 1000000000).ToString();
    }
    
    public void Save(EnemyColors color)
    {
        _saveService.SaveData.AddData(Id, new EnemySaveData(Id, typeof(Enemy), color, transform.position));
    }
    
    public void Load(string id)
    {
        Id = id;
        if (_saveService.SaveData.TryGetData(Id, out EnemySaveData enemySaveData))
        {
            transform.position = enemySaveData.Position.ToVector();
        }
    }
    
    public Enemy SetHealth(int health)
    {
        _health = health;
        return this;
    }

    public Enemy SetType(EnemyColors type)
    {
        _type = type;
        return this;
    }
}

[Serializable]
public class EnemySaveData : SaveData
{
    public Vector3Serialize Position { get; private set; }
   
    public EnemySaveData(string id, Type type, EnemyColors enemyColorType, Vector3 position) : base(id, type, enemyColorType)
    {
        Position = new Vector3Serialize(position);
    }
}
