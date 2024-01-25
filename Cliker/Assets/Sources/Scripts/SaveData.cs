using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class SaveData : MonoBehaviour
{
    public float Value;
    public float ValuePerSecond;
    public float ValuePerClick;

    public SaveData()
    {
        
    }

    public SaveData(float value, float valuePerClick, float valuePerSecond)
    {
        Value = value;
        ValuePerClick = valuePerClick;
        ValuePerSecond = valuePerSecond;
    }
    
}

public class Save : SaveData
{
    public void SaveValue(SaveData saveData)
    {
        string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);
        File.WriteAllText(Application.persistentDataPath + "/SaveData.json", json);
    }

    public void Load(SaveData saveData)
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/SaveData.json"); 
        saveData = JsonConvert.DeserializeObject<SaveData>(json);
        Debug.Log(saveData);
    }
}