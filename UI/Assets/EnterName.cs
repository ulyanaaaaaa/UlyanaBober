using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EnterName : MonoBehaviour
{
    [SerializeField] private Button _nameAcceptButton;
    [SerializeField] private TextMeshProUGUI _newName;
    [SerializeField] private TMP_InputField _inputName;

    private void Awake()
    {
        _nameAcceptButton.onClick.AddListener(CreateName);
        _inputName.onEndEdit.AddListener(CreateName);
    }

    private void CreateName()
    {
        _newName.text = _inputName.text;
        _inputName.text = "";
    }

    private void CreateName(string name)
    {
        _newName.text = name;
        _inputName.text = "";
    }


}
