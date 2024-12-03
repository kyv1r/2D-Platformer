using System;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int _countCoin;

    public int CountCoin => _countCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            coin.Collect();
            _countCoin++;
        }
    }
}
