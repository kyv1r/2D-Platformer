using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private Ability _ability;
    [SerializeField] private EnemyDetector _enemyDetector;

    private PlayerInput _playerInput;
    private Coroutine _cooldownCoroutine;
    private Coroutine _pullHealthCoroutine;

    private float _timeAbility = 6;
    private float _cooldown = 10;
    private float _pulledHealthValue;
    private float _radiusConversionCoefficient = 2;
    private float _frameRateDamage = 0.5f;
    private WaitForSeconds _waitForAbilityTime;
    private WaitForSeconds _waitForCooldown;

    public event Action<float> PulledHealth;

    private void Awake()
    {
        _playerInput = new PlayerInput();

        _waitForAbilityTime = new WaitForSeconds(_timeAbility);
        _waitForCooldown = new WaitForSeconds(_cooldown - _timeAbility);
    }

    private void OnEnable()
    {
        _playerInput.Enable();

        _playerInput.Player.BloodThirst.performed += OnBloodThirst;
    }

    private void OnDisable()
    {
        _playerInput.Disable();

        _playerInput.Player.BloodThirst.performed -= OnBloodThirst;
    }

    private void OnBloodThirst(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            _cooldownCoroutine = StartCoroutine(Cooldown());
            _pullHealthCoroutine = StartCoroutine(PullHealth());
        }
    }

    private IEnumerator Cooldown()
    {
        _playerInput.Disable();
        _enemyDetector.gameObject.SetActive(true);

        yield return _waitForAbilityTime;

        _enemyDetector.gameObject.SetActive(false);

        yield return _waitForCooldown;

        _playerInput.Enable();
    }

    private IEnumerator PullHealth()
    {
        while (_enemyDetector.gameObject.activeSelf)
        {
            if (_ability.SelectTarget(transform.position, _enemyDetector.CircleCollider2D.radius * _radiusConversionCoefficient) != null)
            {
                _ability.ActivateAction(_ability.SelectTarget(transform.position, _enemyDetector.CircleCollider2D.radius * _radiusConversionCoefficient));
                _pulledHealthValue += _ability.AbilityDamageAction.Damage;
                PulledHealth?.Invoke(_pulledHealthValue);
                _pulledHealthValue = 0;
            }

            yield return new WaitForSeconds(_frameRateDamage);
        }

        yield break;
    }
}
