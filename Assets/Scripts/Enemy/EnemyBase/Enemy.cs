using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(EnemyAttacker), typeof(Rotator))]
[RequireComponent(typeof(Rigidbody2D), typeof(PlayerFollower), typeof(AreaPatroller))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _attackDistance = 0.6f;
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private GroundDetector _groundDetector;

    private EnemyMover _movement;
    private EnemyAttacker _attack;
    private Rotator _facing;
    private PlayerFollower _playerFollower;
    private AreaPatroller _areaPatroler;
    private Health _health;

    private Rigidbody2D _rigidbody2D;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    private void Awake()
    {
        _movement = GetComponent<EnemyMover>();
        _attack = GetComponent<EnemyAttacker>();
        _facing = GetComponent<Rotator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _areaPatroler = GetComponent<AreaPatroller>();
        _playerFollower = GetComponent<PlayerFollower>();
        _health = GetComponent<Health>();
    }

    private void FixedUpdate()
    {
        if (_health.IsDie == false)
        {
            if (_playerDetector.TryFindPlayerPosition(out Vector2 playerPosition))
                FollowPlayer(playerPosition);
            else
                Patrol();
        }
        else
        {
            _movement.Rigidbody2D.velocity = Vector2.zero;
        }

    }

    private void Update()
    {
        if (_health.IsDie == false)
        {
            if (_playerDetector.TryFindPlayerPosition(out Vector2 playerPosition))
            {
                if (CanAttackPlayer(playerPosition))
                    _attack.StartAttack();
                else
                    _attack.StopAttack();
            }
            else
            {
                _attack.StopAttack();
            }
        }
        else
        {
            _attack.StopAttack();
        }

    }

    private void Patrol()
    {
        if (_groundDetector.HasGroundBelow == false)
            _facing.Flip();

        _areaPatroler.PatrolArea();
    }

    private void FollowPlayer(Vector2 currentPlayerPosition)
    {
        _playerFollower.Follow(currentPlayerPosition);

        Vector2 direction = currentPlayerPosition - (Vector2)transform.position;
        _facing.SetFacingDirection(direction);

        if (CanAttackPlayer(currentPlayerPosition))
            _movement.Rigidbody2D.velocity = Vector2.zero;
    }

    private bool CanAttackPlayer(Vector2 currentPlayerPosition)
    {
        float distanceToPlayer = ((Vector2)transform.position - currentPlayerPosition).sqrMagnitude;
        return distanceToPlayer <= _attackDistance * _attackDistance;
    }
}
