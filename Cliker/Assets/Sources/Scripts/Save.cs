using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class Save : MonoBehaviour
{
    public void SaveValue(SaveData saveData)
    {
        string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);
        Debug.Log(Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + "/SaveData.json", json);
        Debug.Log("Загрузка данных в файл");
    }

    public void Load(SaveData saveData)
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/SaveData.json"); 
        saveData = JsonConvert.DeserializeObject<SaveData>(json);
        Debug.Log("Загрузка данных из файла");
    }
}