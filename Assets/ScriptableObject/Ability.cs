using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/New Ability")]
public class Ability : ScriptableObject
{
    [SerializeField] private AbilityTouchLogic _touchLogic;
    [SerializeField] private AbilityDamageAction _abilityAction;

    public AbilityDamageAction AbilityDamageAction => _abilityAction;

    public void ActivateAction(List<IDamageable> targets)
    {
        if (targets == null || targets.Count == 0)
        {
            Debug.Log("Нет врагов в радиусе действия способности");
            return;
        }

        foreach (var target in targets)
        {
            _abilityAction.Action(target);
        }
    }

    public List<IDamageable> SelectTarget(Vector2 position, float radius)
    {
        return _touchLogic.TryGetTarget(position, radius);
    }
}
