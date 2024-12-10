using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _layerMaskEnemy;

    private PlayerInput _playerInput;

    public event Action Attacked;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();

        _playerInput.Player.Attack.performed += OnAttack;
    }

    private void OnDisable()
    {
        _playerInput.Disable();

        _playerInput.Player.Attack.performed -= OnAttack;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            Attacked?.Invoke();
    }

    public void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPosition.position, _attackRange, _layerMaskEnemy);

        foreach (var enemy in enemies)
            enemy.GetComponent<IDamageable>().TakeDamage(_damage);
    }
}
