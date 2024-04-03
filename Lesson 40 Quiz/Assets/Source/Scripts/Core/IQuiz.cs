using System.Collections.Generic;

public interface IQuiz
{
    public string Quiz { get; }
    
    public IReadOnlyCollection<Answer> Answers { get; }

    public Answer RightAnswer { get; }
}