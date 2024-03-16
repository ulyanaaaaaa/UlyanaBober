using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AnswerButton : MonoBehaviour
{
   public Action<Answer> OnClick;
   
   [SerializeField] private TextMeshProUGUI _title;
   public Button Button { get; private set; }
   public Answer Answer { get; private set; }

   public void Setup(Answer answer)
   {
      _title.text = answer.Value;
   }
}
