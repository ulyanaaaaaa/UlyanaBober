using System;
using UnityEngine;

[Serializable]
public class Answer
{
    [field: SerializeField] public string Value { get; private set; }

    public Answer(string value)
    {
        Value = value;
    }
}