using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Touch Logic/Single Target")]
public class AbilityTouchLogicSingleTarget : AbilityTouchLogic
{
    [SerializeField] private LayerMask _layerMaskTarget;

    public override List<IDamageable> TryGetTarget(Vector2 position, float radius)
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(position, radius, _layerMaskTarget);

        foreach (Collider2D target in targets)
        {
            if (target.TryGetComponent(out IDamageable damageable))
                return new List<IDamageable>() { target.transform.GetComponent<IDamageable>() };
        }

        return null;
    }
}
