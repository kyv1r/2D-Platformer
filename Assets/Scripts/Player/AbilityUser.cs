using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityUser : MonoBehaviour
{
    [SerializeField] private Ability _ability;
    [SerializeField] private EnemyDetector _enemyDetector;

    private PlayerInput _playerInput;
    private Coroutine _coolDownCoroutine;
    private Coroutine _pullHealthCoroutine;

    private float _timeAbility = 6;
    private float _coolDown = 10;
    private float _pulledHealthValue;
    private float _radiusConversionCoefficient = 2;
    private float _frameRateDamage = 0.5f;

    public event Action<float> PulledHealth;

    private void Awake()
    {
        _playerInput = new PlayerInput();
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
            _coolDownCoroutine = StartCoroutine(CoolDown());
            _pullHealthCoroutine = StartCoroutine(PullHealth());
        }
    }

    private IEnumerator CoolDown()
    {
        _playerInput.Disable();
        _enemyDetector.gameObject.SetActive(true);

        yield return new WaitForSeconds(_timeAbility);

        _enemyDetector.gameObject.SetActive(false);

        yield return new WaitForSeconds(_coolDown - _timeAbility);

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
