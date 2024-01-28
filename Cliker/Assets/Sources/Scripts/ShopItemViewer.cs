using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Image _background;
    [SerializeField] private Image _image;
    private ShopItem _item;

    private void Awake()
    {
        _item = GetComponent<ShopItem>();
        UpdateInfo();
        _item.OnUpdate += UpdateInfo;
    }

    private void Update()
    {
        if (_item.Price <= _wallet.Value)
        {
            _background.color = new Color(158 / 255f, 158 / 255f, 158 / 255f, 1f);
            _image.color = new Color(241 / 255f, 241 / 255f, 241 / 255f, 1f);
        }
        else
        {
            _background.color = new Color(42 / 255f, 32 / 255f, 32 / 255f, 1f);
            _image.color = new Color(78 / 255f, 76 / 255f, 76 / 255f, 1f);
        }
    }

    private void UpdateInfo()
    {
        _price.text = $"Price: {Math.Round(_item.Price, 1)}";
        _description.text = " ";
        _description.text = $"Per second: {Math.Round(_item.ValuePerSecondShop, 1)}\nPer Click: {Math.Round(_item.ValuePerClickShop,1)}";
    }
}
