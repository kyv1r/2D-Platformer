using UnityEngine;

public abstract class AbilityDamageAction : ScriptableObject
{
    public abstract float Damage { get; }

    public abstract void Action(IDamageable target);
}
