using Unity.Mathematics;
using UnityEngine;

public class AnswerButtonFactory : MonoBehaviour
{
    public AnswerButton CreateAnswerButton(Vector2 position, Transform parent)
    {
        AnswerButton answerButtonPrefab = Resources.Load<AnswerButton>(AssetsPath.AnswerButton);
        return Instantiate(answerButtonPrefab, position, quaternion.identity, parent);
    }
}