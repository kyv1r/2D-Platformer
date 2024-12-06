using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(CollisionHandler))]
public class PlayerMovement : MonoBehaviour, IDamageable
{
    [SerializeField] private float _healt;
    [SerializeField] private float _maxHealt = 100;
    [SerializeField] private float _minHealt = 0;
    [SerializeField] private float _damage;
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private float _attackRange;
    [SerializeField] private Player _player;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _layerMaskEnemy;

    public bool _isFacingRight = true;
    private Vector2 _moveDirection;
    private Rigidbody2D _rigidbody;
    private CollisionHandler _collisionHandler;

    public event Action Attacked;

    public bool IsFacingRight
    {
        get
        {
            return _isFacingRight;
        }
        set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    public float Health
    {
        get
        {
            return _healt;
        }
        set
        {
            if (value < _minHealt)
                _healt = _minHealt;
            else if (value > _maxHealt)
                _healt = _maxHealt;
            else
                _healt = value;
        }
    }

    public float MaxHealth { get => _maxHealt; set => _maxHealt = value; }

    public float MinHealth { get => _minHealt; set => _minHealt = value; }

    public float Damage { get => _damage; set => _damage = value; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collisionHandler = GetComponent<CollisionHandler>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_moveDirection.x * _moveSpeed, _rigidbody.velocity.y);
    }

    public void SetFacingDirection(Vector2 direction)
    {
        if (direction.x > 0 && IsFacingRight == false)
            IsFacingRight = true;
        else if (direction.x < 0 && IsFacingRight)
            IsFacingRight = false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.action.ReadValue<Vector2>();
        SetFacingDirection(_moveDirection);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (_collisionHandler.IsTouching)
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
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

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_attackPosition.position, _attackRange);
    }
}
