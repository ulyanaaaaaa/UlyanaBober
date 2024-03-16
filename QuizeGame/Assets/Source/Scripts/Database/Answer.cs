using System;
using UnityEngine;

[Serializable]
public class Answer
{
    [field: SerializeField] public string Value { get; }

    public Answer(string value)
    {
        Value = value;
    }
}
