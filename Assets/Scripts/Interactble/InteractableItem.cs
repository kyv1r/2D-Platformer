using System;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField] protected float _value;

    public event Action<InteractableItem> Collected;

    public float Value => _value;

    public virtual void Collect()
    {
        Collected?.Invoke(this);
        Invoke(nameof(DeactivateObject), 0.1f);
    }

    private void DeactivateObject()
    {
        gameObject.SetActive(false);
    }

}