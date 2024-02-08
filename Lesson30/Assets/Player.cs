using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Timer))]
public class Player : MonoBehaviour
{
    [SerializeField] private Button _stone;
    [SerializeField] private Button _scissors;
    [SerializeField] private Button _paper;

    private Hand _playerHand;
    private Enemy _enemy;
    private Timer _timer;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _timer = GetComponent<Timer>();
        _stone.onClick.AddListener(PlayerHand); 
        _scissors.onClick.AddListener(PlayerHand); 
        _paper.onClick.AddListener(PlayerHand); 
    }

    public void PlayerHand()
    {
        _enemy.SetRandomHand();
        ShutdownButtons();
        ComparisonHands();
    }

    private void ShutdownButtons()
    {
        _stone.GameObject().SetActive(false);
        _scissors.GameObject().SetActive(false);
        _paper.GameObject().SetActive(false);
    }

    private void ComparisonHands()
    {
        if (_playerHand == Hand.Paper && _enemy.Hand == Hand.Stone)
            Debug.Log("You win!");
        else if (_playerHand == Hand.Scissors && _enemy.Hand == Hand.Paper)
            Debug.Log("You win!");
        else if (_playerHand == Hand.Stone && _enemy.Hand == Hand.Scissors)
            Debug.Log("You win!");
        else
            Debug.Log("You loos");
    }
}
