using System;
using UnityEngine;

public class JudgeHandler : MonoBehaviour
{
   public Action OnFail;
   [SerializeField] private QuizViewer _quizViewer;
   [SerializeField] private int _attempts;

   private bool _isFail;

   private void Awake()
   {
      _quizViewer.OnSelect += ChaiceHandle;
   }

   private void ChaiceHandle(bool right)
   {
      if (_isFail)
         return;
      if (!right)
      {
         _attempts--;
      }

      if (_attempts <= 0)
      {
         _isFail = true;
         OnFail?.Invoke();
      }
   }
}
