using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxValue = 100;
    [SerializeField] private float _minValue = 0;
    [SerializeField] private float _currentValue;

    public event Action<float> HealthChanged;
    public event Action OnDied;

    public float CurrentValue
    {
        get => _currentValue;
        private set
        {
            _currentValue = Mathf.Clamp(value, _minValue, _maxValue);
            HealthChanged?.Invoke(_currentValue);

            if (_currentValue <= _minValue)
                OnDied?.Invoke();
        }
    }

    public float MaxValue => _maxValue;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        CurrentValue -= damage;
    }

    public void Heal(float amount)
    {
        CurrentValue += amount;
    }
}
