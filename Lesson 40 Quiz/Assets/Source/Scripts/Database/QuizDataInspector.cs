using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuizDataInspector : QuizDataAdapter
{
    [SerializeField] private string _quiz;
    [SerializeField] private List<Answer> _answers;
    [SerializeField] private Answer _rightAnswer;
    
    public QuizData GetQuizData()
    {
        return new QuizData(_quiz, _answers, _rightAnswer);
    }
}