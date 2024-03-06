using System.ComponentModel;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _money;

    public void AddMoney(int count)
    {
        if (count < 0)
            throw new WarningException("Out of range");
        
        _money += count;
    }
    
    public void RemoveMoney(int count)
    {
        if (count < 0)
            throw new WarningException("Out of range");
        
        _money -= count;
    }
}
