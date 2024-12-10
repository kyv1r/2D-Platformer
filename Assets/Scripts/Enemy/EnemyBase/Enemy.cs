using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(EnemyAttack), typeof(Facing))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _attackDistance = 0.6f;
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private GroundDetector _groundDetector;

    private EnemyMover _movement;
    private EnemyAttack _attack;
    private Facing _facing;

    private Rigidbody2D _rigidbody2D;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    private void Awake()
    {
        _movement = GetComponent<EnemyMover>();
        _attack = GetComponent<EnemyAttack>();
        _facing = GetComponent<Facing>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_playerDetector.IsPlayerDetected)
            FollowPlayer();
        else
            Patrol();
    }

    private void Update()
    {
        _playerDetector.FindPlayerPosition();

        if (_playerDetector.IsPlayerDetected)
            AttackPlayer();
    }

    private void Patrol()
    {
        if (_groundDetector.HasGroundBelow == false)
            _facing.Flip();

        _movement.PatrolArea();
    }

    private void FollowPlayer()
    {
        Vector2 playerPosition = _playerDetector.FindPlayerPosition();
        _movement.FollowPlayer(playerPosition);

        float distanceToPlayer = ((Vector2)transform.position - playerPosition).sqrMagnitude;

        if (distanceToPlayer <= _attackDistance * _attackDistance)
            _movement.Rigidbody2D.velocity = Vector2.zero;
    }

    private void AttackPlayer()
    {
        Vector2 playerPosition = _playerDetector.FindPlayerPosition();
        float distanceToPlayer = ((Vector2)transform.position - playerPosition).sqrMagnitude;

        if (distanceToPlayer <= _attackDistance * _attackDistance)
            _attack.StartAttack();
        else
            _attack.StopAttack();

        _facing.SetFacingDirection(_movement.CurrentDirection);
    }
}
