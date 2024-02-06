using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[RequireComponent(typeof(EnemyFabrica))]

public class SaveService : MonoBehaviour
{
    private string _filePath;
    private EnemyFabrica _enemyFabrica;
    
    public LevelSaveData SaveData { get; private set; }

    private void OnEnable()
    {
        _filePath = Application.persistentDataPath + "/Save.json";
        Load();
    }

    private void Awake()
    {
        _enemyFabrica = GetComponent<EnemyFabrica>();
    }

    [ContextMenu("Save")]
    public void Save()
    {
        using (FileStream file = File.Create(_filePath))
        {
            new BinaryFormatter().Serialize(file, SaveData);
        }
    }

    [ContextMenu("Load")]
    public void Load()
    {
        using (FileStream file = File.Open(_filePath, FileMode.Open))
        {
            object loadedData = new BinaryFormatter().Deserialize(file);
            SaveData = (LevelSaveData)loadedData;
        }
    }

    private void LoadLevel()
    {
        foreach (SaveData data in SaveData.Data.Values)
        {
            if (data.Type == typeof(Enemy))
            {
                EnemySaveData enemySaveData = (EnemySaveData) data;
                
                if (data.TypeEnemy == Enemies.Black)
                    _enemyFabrica.CreateBlackEnemy(enemySaveData.Position.ToVector()).Load(data.Id);
                if (data.TypeEnemy == Enemies.White)
                    _enemyFabrica.CreateWhiteEnemy(enemySaveData.Position.ToVector()).Load(data.Id);
                if (data.TypeEnemy == Enemies.Red)
                    _enemyFabrica.CreateRedEnemy(enemySaveData.Position.ToVector()).Load(data.Id);
                if (data.TypeEnemy == Enemies.Green)
                    _enemyFabrica.CreateGreenEnemy(enemySaveData.Position.ToVector()).Load(data.Id);
                if (data.TypeEnemy == Enemies.Blue)
                    _enemyFabrica.CreateBlueEnemy(enemySaveData.Position.ToVector()).Load(data.Id);
            }
        }
    }
}

[Serializable]
public class LevelSaveData
{
    public Dictionary<string, SaveData> Data = new Dictionary<string, SaveData>();

    public void AddData(string id, SaveData data)
    {
        Data.TryAdd(id, data);
    }

    public bool TryGetData<T>(string id, out T data) where T : SaveData
    {
        foreach (SaveData dataList in Data.Values)
        {
            if (dataList.Id == id)
            {
                data = (T)dataList;
                return true;
            }
        }
        data = null;
        return false;
    }
    
    public LevelSaveData()
    {

    }
}

[Serializable]
public class SaveData
{
    public string Id { get; private set; }
    public Type Type { get; private set; }
    public Enemies TypeEnemy { get; private set; }
    

    public SaveData(string id, Type type, Enemies typeEnemy)
    {
        Id = id;
        Type = type;
        TypeEnemy = typeEnemy;
    }
}

[Serializable]
public class Vector3Serialize
{
    public float X { get; private set; }
    public float Y { get; private set; }
    public float Z { get; private set; }
    
    
    public Vector3Serialize(Vector3 vector)
    {
        X = vector.x;
        Y = vector.y;
        Z = vector.z;
    }

    public Vector3 ToVector()
    {
        return new Vector3(X,Y,Z);
    }
}
