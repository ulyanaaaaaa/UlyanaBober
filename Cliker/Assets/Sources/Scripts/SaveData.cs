using System.Collections.Generic;
using UnityEngine;

public class SaveData 
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