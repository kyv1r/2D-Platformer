using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Action/Pull Health")]
public class AbilityActionPullHealth : AbilityDamageAction
{
    [SerializeField] private float _damage;

    public override float Damage => _damage;

    public override void Action(IDamageable target)
    {
        target.TakeDamage(_damage);
    }
}
