using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[RequireComponent(typeof(EnemyFabrica))]

public class SaveService : MonoBehaviour
{
    private string _filePath;
    [SerializeField] private EnemyFabrica _enemyFabrica;

    public LevelSaveData SaveData { get; private set; }

    private void OnEnable()
    {
        _filePath = Application.persistentDataPath + "/Save.json";

        if (File.Exists(_filePath))
        {
            Load();
        }
        else
        {
            SaveData = new LevelSaveData();
            Save();
        }
    }

    private void Awake()
    {
        _enemyFabrica = GetComponent<EnemyFabrica>();
    }
    
    public void Save()
    {
        if (SaveData != null)
        {
            using (FileStream file = File.Create(_filePath))
            {
                new BinaryFormatter().Serialize(file, SaveData);
            }
        }
        else
        {
            Debug.Log("SaveData is null");
        }
    }
    
    public void Load()
    {
        using (FileStream file = File.Open(_filePath, FileMode.Open))
        {
            object loadedData = new BinaryFormatter().Deserialize(file);
            SaveData = (LevelSaveData)loadedData;
        }
        LoadLevel();
    }

    private void LoadLevel()
    {
        foreach (SaveData data in SaveData.Data.Values)
        {
            if (data.Type == typeof(Enemy))
            {
                EnemySaveData enemySaveData = (EnemySaveData) data;
                _enemyFabrica.CreateEnemy(enemySaveData.Position.ToVector(), data.Color).Load(data.Id);
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
    public EnemyColors Color { get; private set; }
    

    public SaveData(string id, Type type, EnemyColors color)
    {
        Id = id;
        Type = type;
        Color = color;
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
