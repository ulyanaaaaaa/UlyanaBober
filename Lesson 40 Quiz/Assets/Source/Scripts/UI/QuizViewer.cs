using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AnswerButtonFactory))]
public class QuizViewer : MonoBehaviour
{
    public Action<bool> OnSelect;
    
    [SerializeField] private TextMeshProUGUI _title;

    [Header("Visual Settings")]
    [SerializeField] private float _spaceBetweenButtons;

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
            throw new Exception("Quiz source doesn't have any quiz.");
        }

        _currentQuiz = _quizSource.Quizzes[_quizIndex];
        SetupQuiz();
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
            AnswerButton answerButtonCreated = _buttonFactory.CreateAnswerButton(transform.position + new Vector3(0, _spaceBetweenButtons * index, 0), transform);
            answerButtonCreated.Setup(answer);
            answerButtonCreated.OnClick += (answer) => CheckAnswer(answer, answerButtonCreated);
            _buttonsCreated.Add(answerButtonCreated);
        }
    }

    private void NextQuiz()
    {
        _quizIndex++;
        if (_quizIndex < _quizSource.Quizzes.Count)
        {
            _currentQuiz = _quizSource.Quizzes[_quizIndex];
            SetupQuiz();
        }
        else
        {
            Debug.Log("All quiz were completed");
        }
    }

    private void CheckAnswer(Answer answer, AnswerButton answerButton)
    {
        OnSelect?.Invoke(answer.Value == _currentQuiz.RightAnswer.Value);
        if (answer.Value == _currentQuiz.RightAnswer.Value)
        {
            NextQuiz();
        }
        else
        {
            answerButton.Fail();
        }
    }
}
