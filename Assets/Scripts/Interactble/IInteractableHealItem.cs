using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractableHealItem
{
    public float HealingPoint {  get; set; }

    public float Heal();
    public void Collect();
}
