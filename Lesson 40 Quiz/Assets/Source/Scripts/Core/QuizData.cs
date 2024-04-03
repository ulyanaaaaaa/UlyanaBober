using System;
using System.Collections.Generic;


[Serializable]
public class QuizData : IQuiz
{
    public string Quiz { get; }
    
    public IReadOnlyCollection<Answer> Answers { get; }

    public Answer RightAnswer { get; }

    public QuizData(string quiz, List<Answer> answers, Answer rightAnswer)
    {
        Quiz = quiz;
        Answers = answers;
        RightAnswer = rightAnswer;
    }
}