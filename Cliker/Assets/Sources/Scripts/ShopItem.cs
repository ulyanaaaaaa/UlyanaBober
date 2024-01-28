using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ShopItem : MonoBehaviour
{
    public Action OnUpdate;
    [field: SerializeField] public float ValuePerClickShop { get; private set; }
    [field: SerializeField] public float ValuePerSecondShop { get; private set; }
    [field: SerializeField] public float Price { get; private set; } 

    [SerializeField] private Abilities _abilities;
    [SerializeField] private Wallet _wallet;
   
    private Button _button;

    private void Awake()
    {
        Load();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(TryBuy);
    }

    private void Load()
    {
        if (PlayerPrefs.GetFloat("ValuePerClickShop") != 0)
            ValuePerClickShop = PlayerPrefs.GetFloat("ValuePerClickShop");

        if (PlayerPrefs.GetFloat("ValuePerSecondShop") != 0)
            ValuePerSecondShop = PlayerPrefs.GetFloat("ValuePerSecondShop");

        if (PlayerPrefs.GetFloat("Price") != 0)
            Price = PlayerPrefs.GetFloat("Price");
    }

    [ContextMenu("Delete")]
    private void DeleteSave() => PlayerPrefs.DeleteAll();

    private void TryBuy()
    {
        if (_wallet.TrySpend(Price)) {
            Price *= 1.25f;
            _abilities.AddValuePerClick(ValuePerClickShop);
            _abilities.AddValuePerSecond(ValuePerSecondShop);
            ValuePerClickShop *= 1.1f;
            ValuePerSecondShop *= 1.1f;
            OnUpdate?.Invoke();
            PlayerPrefs.SetFloat("ValuePerClickShop", ValuePerClickShop);
            PlayerPrefs.SetFloat("ValuePerSecondShop", ValuePerSecondShop);
            PlayerPrefs.SetFloat("Price", Price);
            
        }
    }
}
