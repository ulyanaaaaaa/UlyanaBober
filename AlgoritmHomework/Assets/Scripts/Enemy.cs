using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Enemies
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
    
    private Enemies _type;
    private Transform _enemy;

    [field: SerializeField] public string Id { get; set; } = "";
    public List<Enemy> CreatedEnemy = new List<Enemy>();

    private void Start()
    {
        if (Id == "")
            Id = Random.Range(0, 1000000000).ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            ListSort(Enemies.Black);
        if (Input.GetKeyDown(KeyCode.S))
            ListSort(Enemies.Red);
        if (Input.GetKeyDown(KeyCode.E))
            ListSort(Enemies.Blue);
    }

    [ContextMenu("Save")]
    public void Save()
    {
        SaveBlackEnemies();
        SaveBlueEnemies();
        SaveGreenEnemies();
        SaveRedEnemies();
        SaveWhiteEnemies();
    }

    private void SaveBlackEnemies() =>
        _saveService.SaveData.AddData(Id, new EnemySaveData(Id, typeof(Enemy),Enemies.Black, transform.position));
    
    
    private void SaveRedEnemies() =>
        _saveService.SaveData.AddData(Id, new EnemySaveData(Id, typeof(Enemy),Enemies.Red, transform.position));

    private void SaveBlueEnemies() =>
        _saveService.SaveData.AddData(Id, new EnemySaveData(Id, typeof(Enemy),Enemies.Blue, transform.position));

    private void SaveGreenEnemies() =>
        _saveService.SaveData.AddData(Id, new EnemySaveData(Id, typeof(Enemy),Enemies.Green, transform.position));

    private void SaveWhiteEnemies()=>
        _saveService.SaveData.AddData(Id, new EnemySaveData(Id, typeof(Enemy),Enemies.White, transform.position));
    
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

    public Enemy SetType(Enemies type)
    {
        _type = type;
        return this;
    }
    
    private void ListSort(Enemies type)
    {
        var selectedEnemies = from enemy in CreatedEnemy
            where enemy._type == type
            select enemy;
        
        foreach (var enemy in selectedEnemies)
            Debug.Log(enemy);
    }
}

[Serializable]
public class EnemySaveData : SaveData
{
    public Vector3Serialize Position { get; private set; }
    public Enemies Type;
    
    public EnemySaveData(string id, Type type, Enemies enemyType, Vector3 position) : base(id, type, enemyType)
    {
        Position = new Vector3Serialize(position);
    }
}
