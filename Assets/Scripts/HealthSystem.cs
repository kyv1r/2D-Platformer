using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _minHealth = 0;
    [SerializeField] private float _currentHealth;

    public event Action<float> OnHealthChanged;
    public event Action OnDied;

    public float CurrentHealth
    {
        get => _currentHealth;
        private set
        {
            _currentHealth = Mathf.Clamp(value, _minHealth, _maxHealth);
            OnHealthChanged?.Invoke(_currentHealth);

            if (_currentHealth <= _minHealth)
                OnDied?.Invoke();
        }
    }

    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
    }

    public void Heal(float amount)
    {
        CurrentHealth += amount;
    }
}
