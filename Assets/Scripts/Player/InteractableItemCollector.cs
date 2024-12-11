using System;
using UnityEngine;

public class InteractableItemCollector : MonoBehaviour
{
    public event Action<float, InteractableItem> Collected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out InteractableItem item))
        {
            Collected?.Invoke(item.Value, item);
            item.Collect();
        }
    }
}
