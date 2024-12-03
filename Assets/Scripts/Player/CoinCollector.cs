using System;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public event Action FindedCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
            FindedCoin?.Invoke();
    }
}
