using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerDetector _playerDetector;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _currentDirection = Vector2.zero;

    public PlayerDetector PlayerDetector => _playerDetector;
    public Vector2 CurrentDirection => _currentDirection;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public GroundDetector GroundDetector => _groundDetector;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void FollowPlayer(Vector2 playerPosition)
    {
        Vector2 direction = playerPosition - (Vector2)transform.position;
        _rigidbody2D.velocity = new Vector2(direction.x * _speed, _rigidbody2D.velocity.y);
        _currentDirection = direction;

    }

    public void PatrolArea()
    {
        float moveDirection = Mathf.Sign(transform.localScale.x);
        _rigidbody2D.velocity = new Vector2(moveDirection * _speed, _rigidbody2D.velocity.y);
        _currentDirection = new Vector2(moveDirection, 0);
    }
}
