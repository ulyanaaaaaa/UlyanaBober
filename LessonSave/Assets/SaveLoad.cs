using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class SaveLoad : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Servises servises = new Servises();
            
            string jsonPlayer = JsonConvert.SerializeObject(servises.GetService<PlayerService>(), Formatting.Indented);
            string jsonWallet = JsonConvert.SerializeObject(servises.GetService<WalletService>(), Formatting.Indented);
            
            File.WriteAllText(Application.persistentDataPath + "/SaveData.json", jsonPlayer);
            File.WriteAllText(Application.persistentDataPath + "/SaveData.json", jsonWallet);
            
            Debug.Log(Application.persistentDataPath + "/SaveData.json");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/SaveData.json");
            
            Service service = JsonConvert.DeserializeObject<EnemyService>(json);
            Debug.Log(service.Name);
            
            Service serviceWallet = JsonConvert.DeserializeObject<WalletService>(json);
            Debug.Log(serviceWallet.Name);
        }
    }
}

public class Servises
{
    public List<Service> _services = new List<Service>();

    public Servises()
    {
        _services.Add(new EnemyService());
        _services.Add(new SaveService());
        _services.Add(new PlayerService());
        _services.Add(new WalletService());
    }

    public T GetService<T>() where T : Service
    {
        foreach (Service serviceList in _services)
        {
            if (serviceList is T)
            {
                return (T)serviceList;
            }
        }
        return null;
    }
}

public class Service
{
    public string Name { get; protected set; }
}

public class SaveService : Service
{
    public SaveService()
    {
        Name = "Save Service";
    }
}

public class WalletService : Service
{
    public WalletService()
    {
        Name = "Wallet Service";
    }
}

public class EnemyService : Service
{
    public EnemyService()
    {
        Name = "Enemy Service";
    }
}

public class PlayerService : Service
{
    public PlayerService()
    {
        Name = "Player Service";
    }
}