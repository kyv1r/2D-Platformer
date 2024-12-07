using System;
using UnityEngine;

public class InteractableItemCollector : MonoBehaviour
{
    private int _countCoin;
    private float _healPoint;

    public event Action Healed;

    public int CountCoin => _countCoin;
    public float HealPoint => _healPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            coin.Collect();
            _countCoin++;
        }

        if (collision.TryGetComponent<IInteractableHealItem>(out IInteractableHealItem healItem))
        {
            healItem.Collect();
            _healPoint = healItem.Heal();
            Healed?.Invoke();
        }
    }
}
