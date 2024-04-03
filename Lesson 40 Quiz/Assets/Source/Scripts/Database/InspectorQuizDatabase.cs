using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class InspectorQuizDatabase : MonoBehaviour, IQuizSource
{
    public ReadOnlyCollection<IQuiz> Quizzes
    {
        get
        {
            List<IQuiz> quizData = new List<IQuiz>();
            foreach (QuizDataInspector data in _data)
            {
                quizData.Add(data.GetQuizData());
            }

            return new ReadOnlyCollection<IQuiz>(quizData);
        }
    }

    [SerializeField] private List<QuizDataInspector> _data;
}

