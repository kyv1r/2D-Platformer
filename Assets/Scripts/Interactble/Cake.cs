using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour, IInteractableHealItem
{
    [SerializeField] private float _healPoint;

    public event Action Collected;

    public float HealingPoint { get => _healPoint; set => _healPoint = value; }

    public void Collect()
    {
        Collected?.Invoke();
        gameObject.SetActive(false);
    }

    public float Heal()
    {
        return HealingPoint;
    }

}
