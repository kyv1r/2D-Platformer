using UnityEngine;

public class HealthValueView : MonoBehaviour
{
    [SerializeField] protected Health Health;

    public float HealthValue {  get; private set; } 
    protected float MaxHealthValue { get; private set; }

    protected virtual void Init()
    {
        HealthValue = Health.CurrentValue;
        MaxHealthValue = Health.MaxValue;
    }

    private void OnEnable()
    {
        Health.HealthChanged += SetCurrentHealthValue;
    }

    private void OnDisable()
    {
        Health.HealthChanged -= SetCurrentHealthValue;
    }

    protected virtual void SetCurrentHealthValue(float healthValue)
    {
        HealthValue = healthValue;
    }
}
