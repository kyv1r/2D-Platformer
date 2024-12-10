using System;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField] protected float _value;

    public event Action Collected;

    public float Value => _value;

    public virtual void Collect()
    {
        Collected.Invoke();
        gameObject.SetActive(false);
    }
}