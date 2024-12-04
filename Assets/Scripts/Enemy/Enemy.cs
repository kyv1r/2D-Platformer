using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private List<WaypointEnemy> _waypoints;

    private Rigidbody2D _rigidbody2D;
    private int _currentIndex;
    public bool _isFacingRight = true;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

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

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        Vector2 targetPosition = _waypoints[_currentIndex].transform.position;
        float distance = Vector2.Distance(transform.position, targetPosition);

        if (distance <= 0.1f)
        {
            _currentIndex = (_currentIndex + 1 ) % _waypoints.Count;
        }

        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        _rigidbody2D.velocity = new Vector2(direction.x * _speed, _rigidbody2D.velocity.y);

        SetFacingDirection(direction);
    }

    public void SetFacingDirection(Vector2 direction)
    {
        if (direction.x > 0 && IsFacingRight == false)
            IsFacingRight = true;
        else if (direction.x < 0 && IsFacingRight)
            IsFacingRight = false;
    }
}
