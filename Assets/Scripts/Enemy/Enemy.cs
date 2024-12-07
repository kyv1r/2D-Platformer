using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float _healt;
    [SerializeField] private float _maxHealt = 100;
    [SerializeField] private float _minHealt = 0;
    [SerializeField] private float _damage;
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _layerMaskPlayer;
    [SerializeField] private float _speed;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerDetector _playerDetector;

    private float _minAttackDistance = 0.7f;
    private float _attackRate = 1f;
    private Coroutine _attackCoroutine;
    private bool _isAttack = false;
    public bool _isFacingRight = true;
    private Rigidbody2D _rigidbody2D;

    public event Action Attacked;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

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

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _playerDetector.GetPlayerPosition();

        if (_playerDetector.IsPlayerDetected)
            FollowPlayer();
        else
            PatrolArea();
    }

    public void FollowPlayer()
    {
        Vector2 playerPosition = _playerDetector.GetPlayerPosition();

        Vector2 direction = playerPosition - (Vector2)transform.position;
        float distance = direction.sqrMagnitude;
        direction.Normalize();

        _rigidbody2D.velocity = new Vector2(direction.x * _speed, _rigidbody2D.velocity.y);

        if (distance <= _minAttackDistance * _minAttackDistance)
        {
            _isAttack = true;
            _attackCoroutine = StartCoroutine(WaitForNextAttack());
            _rigidbody2D.velocity = Vector2.zero;
        }

        _isAttack = false;
        SetFacingDirection(direction);

    }

    public void PatrolArea()
    {
        bool isGroundDetected = _groundDetector.CheckGround();

        if (isGroundDetected == false)
            SetFacingDirection(new Vector2(-transform.localScale.x, 0));

        float moveDirection = IsFacingRight ? 1 : -1;
        _rigidbody2D.velocity = new Vector2(moveDirection * _speed, _rigidbody2D.velocity.y);
    }

    public void SetFacingDirection(Vector2 direction)
    {
        if (direction.x > 0 && IsFacingRight == false)
            IsFacingRight = true;
        else if (direction.x < 0 && IsFacingRight)
            IsFacingRight = false;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public void Attack()
    {
        Collider2D[] players = Physics2D.OverlapCircleAll(_attackPosition.position, _attackRange, _layerMaskPlayer);

        foreach (var player in players)
        {
            player.GetComponent<IDamageable>().TakeDamage(_damage);
        }
    }

    private IEnumerator WaitForNextAttack()
    {
        WaitForSeconds periodicityAttack = new WaitForSeconds(_attackRate);

        while (_isAttack)
        {
            Attacked?.Invoke();
            yield return periodicityAttack;
        }
    }
}
