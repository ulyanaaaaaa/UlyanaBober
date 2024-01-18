using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePicture : MonoBehaviour
{
    [SerializeField] private Dropdown _dropdown;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Sprite _elfSprite;
    [SerializeField] private Sprite _wizardSprite;
    [SerializeField] private Sprite _witchSprite;
    List<Sprite> sprites = new List<Sprite>();
    List<string> items = new List<string>();

    private void Awake()
    {
        items.Add("Wizard");
        items.Add("Elf");
        items.Add("Witch");

        sprites.Add(_wizardSprite);
        sprites.Add(_elfSprite);
        sprites.Add(_witchSprite);

        _dropdown.onValueChanged.AddListener(Choose);
    }
  
    private void Choose(int index)
    {
        DropdownItemSelected(index);
        ChangeImage(index);
    }

    private void DropdownItemSelected(int index)
    {
        _text.text = _dropdown.options[index].text;
    }
    private void ChangeImage(int index)
    {
        _image.sprite = sprites[index];
    }

}
