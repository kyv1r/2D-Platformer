using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
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
        }
    }

    public float MaxValue => _maxValue;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
        {
            CurrentValue -= damage;

            if (_currentValue <= _minValue)
                OnDied?.Invoke();
        }
    }

    public void Heal(float amount)
    {
        if (amount >= 0)
            CurrentValue += amount;
    }
}
