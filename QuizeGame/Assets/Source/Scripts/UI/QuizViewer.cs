using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AnswerButtonFactory))]
public class QuizViewer : MonoBehaviour
{
    public Action<bool> OnSelect;

    [Header("Visual Settings")] [SerializeField]
    private float _spaceBetweenButtons;
    
    [SerializeField] private TextMeshProUGUI _title;

    private IQuiz _currentQuiz;
    private IQuizSource _quizSource;
    private AnswerButtonFactory _buttonFactory;
    private List<AnswerButton> _buttonsCreated = new List<AnswerButton>();
    private int _quizIndex;

    private void Awake()
    {
        _quizIndex = 0;
        _quizSource = GetComponent<IQuizSource>();
        _buttonFactory = GetComponent<AnswerButtonFactory>();

        if (_quizSource.Quizzes.Count == 0)
        {
            throw new Exception("Quiz is null");
        }

        _currentQuiz = _quizSource.Quizzes[0];
    }

    private void SetupQuiz()
    {
        foreach (AnswerButton button in _buttonsCreated)
        {
            Destroy(button.gameObject);
        }
        _buttonsCreated.Clear();
        
        _title.text = _currentQuiz.Quiz;
        int index = 0;
        foreach (Answer answer in _currentQuiz.Answers)
        {
            index++;
            AnswerButton answerButtonCreated = _buttonFactory.CreateAnswerButton(transform.position 
                + new Vector3(0, 50 * index, 0), transform);
            answerButtonCreated.OnClick += CheckAnswer;
            answerButtonCreated.Setup(answer);
            _buttonsCreated.Add(answerButtonCreated);
        }
    }

    private void NextQuiz()
    {
        _quizIndex++;
        if (_quizIndex<_quizSource.Quizzes.Count)
        {
            _currentQuiz = _quizSource.Quizzes[_quizIndex];
            SetupQuiz();    
        }
        else
        {
            Debug.Log("All quiz were complited!");
        }
    }

    private void CheckAnswer(Answer answer)
    {
        OnSelect?.Invoke(answer.Value == _currentQuiz.RightAnswer.Value);
        if (answer.Value == _currentQuiz.RightAnswer.Value)
        {
            NextQuiz();
        }
    }
}
