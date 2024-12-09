using UnityEngine;

[RequireComponent(typeof(EnemyMovement), typeof(EnemyAttack), typeof(EnemyFacing))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _attackDistance = 0.6f;
    [SerializeField] private PlayerDetector _playerDetector;

    private EnemyMovement _movement;
    private EnemyAttack _attack;
    private EnemyFacing _facing;

    private Rigidbody2D _rigidbody2D;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    private void Awake()
    {
        _movement = GetComponent<EnemyMovement>();
        _attack = GetComponent<EnemyAttack>();
        _facing = GetComponent<EnemyFacing>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _playerDetector.SetPlayerPosition();

        if (_playerDetector.IsPlayerDetected)
        {
            Vector2 playerPosition = _playerDetector.SetPlayerPosition();
            _movement.FollowPlayer(playerPosition);

            float distanceToPlayer = ((Vector2)transform.position - playerPosition).sqrMagnitude;

            if (distanceToPlayer <= _attackDistance * _attackDistance)
                _movement.Rigidbody2D.velocity = Vector2.zero;
        }
        else
        {
            if (_movement.GroundDetector.HasGroundBelow == false)
                _facing.Flip();

            _movement.PatrolArea();
        }
    }

    private void Update()
    {
        _playerDetector.SetPlayerPosition();

        if (_playerDetector.IsPlayerDetected)
        {
            Vector2 playerPosition = _playerDetector.SetPlayerPosition();
            float distanceToPlayer = ((Vector2)transform.position - playerPosition).sqrMagnitude;

            if (distanceToPlayer <= _attackDistance * _attackDistance)
                _attack.StartAttack();
            else
                _attack.StopAttack();

            _facing.SetFacingDirection(_movement.CurrentDirection);
        }
    }
}
