using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityTouchLogic : ScriptableObject
{
    public abstract List<IDamageable> TryGetTarget(Vector2 position, float radius);
}
