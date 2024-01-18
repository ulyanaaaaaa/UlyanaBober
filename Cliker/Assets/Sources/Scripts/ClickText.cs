using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ClickText : MonoBehaviour
{
    [SerializeField] private GameObject _effect;
    [SerializeField] private GameObject _button;
    [SerializeField] private Diamond _diamond;

    private void Awake()
    {
        _diamond.OnClickText += TextClick;
    }

    private void TextClick()
    {
        Instantiate(_effect, _button.GetComponent<Transform>().position.normalized, Quaternion.identity);
    }
}
