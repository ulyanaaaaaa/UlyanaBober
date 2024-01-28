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
    }

    public SaveData Load()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/SaveData.json"); 
        return JsonConvert.DeserializeObject<SaveData>(json);
    }
}