using Mono.Collections.Generic;

public interface IQuizSource
{
   public ReadOnlyCollection<IQuiz> Quizzes { get; }
}
