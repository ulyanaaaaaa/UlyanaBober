using UnityEngine;

public class CoinsFabrica : MonoBehaviour
{
    public Coin CreateCoin()
    {
        Coin coin = Resources.Load<Coin>("Coin");
        Vector2 randomPosition = new Vector2(8.35f, Random.Range(-3.5f, 3.5f));
        return Instantiate(coin, randomPosition, Quaternion.identity);
    }
}
