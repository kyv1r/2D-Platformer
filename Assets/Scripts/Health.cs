using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterAnimator))]
public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxValue = 100;
    [SerializeField] private float _minValue = 0;
    [SerializeField] private float _currentValue;

    private CharacterAnimator _characterAnimator;
    private Coroutine _dieCoroutine;
    private WaitForSeconds _waitForDie;

    private bool _isDie = false;
    private float _timeToDie = 1.5f;

    public event Action<float> HealthChanged;

    public bool IsDie => _isDie;

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
        _characterAnimator = GetComponent<CharacterAnimator>();
        _waitForDie = new WaitForSeconds(_timeToDie);
    }

    public void TakeDamage(float damage)
    {
        if (damage >= 0 && _isDie == false)
        {
            CurrentValue -= damage;

            if (_currentValue <= _minValue)
                Die();
        }
    }

    public void Heal(float amount)
    {
        if (amount >= 0)
            CurrentValue += amount;
    }

    public void Die()
    {
        if (_isDie) return;

        _isDie = true;

        _characterAnimator.PlayDie();
        _dieCoroutine = StartCoroutine(DieDuration());
    }

    private IEnumerator DieDuration()
    {
        yield return _waitForDie;

        gameObject.SetActive(false);

        yield break;
    }
}
