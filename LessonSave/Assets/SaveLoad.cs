using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class SaveLoad : MonoBehaviour
{
    private void Update()
    {
        //сохранение
        if (Input.GetKeyDown(KeyCode.W))
        {
            string json = JsonConvert.SerializeObject(new Gold(Random.Range(1, 1000), "Ulyana"), Formatting.Indented);
            File.WriteAllText(Application.persistentDataPath + "/SaveData.json", json);
            Debug.Log(Application.persistentDataPath + "/SaveData.json");
        }
        //считывание
        if (Input.GetKeyDown(KeyCode.S))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/SaveData.json");
            Gold gold = JsonConvert.DeserializeObject<Gold>(json);
            Debug.Log(gold.Count + gold.WalletName);
        }
    }
}

public class Gold
{
    public int Count;
    public string WalletName;

   public Gold(int count, string walletName)
    {
        Count = count;
        WalletName = walletName;
    }
    
}