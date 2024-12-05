using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerDetector _playerDetector;

    public bool _isFacingRight = true;
    private Rigidbody2D _rigidbody2D;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

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
        Move();
    }

    public void Move()
    {
        bool isGroundDetected = _groundDetector.CheckGround();

        if (isGroundDetected == false)
            SetFacingDirection(new Vector2(-transform.localScale.x, 0));

        if (_playerDetector.TryGetPlayerPosition(out Vector2 playerPosition))
        {
            Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;
            float distance = Vector2.Distance(transform.position, playerPosition);
            Debug.Log(distance);

            if (distance <= 0.3f)
            {
                Debug.Log("asdasd");
                _rigidbody2D.velocity = Vector2.zero;
                return;
            }

            _rigidbody2D.velocity = new Vector2(direction.x * _speed, _rigidbody2D.velocity.y);

            return;
        }

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
}
