
using System.Collections.ObjectModel;

public interface IQuizSource
{
    public ReadOnlyCollection<IQuiz> Quizzes { get; }
}
