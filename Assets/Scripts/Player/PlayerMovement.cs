using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    public bool _isFacingRight = true;
    private Vector2 _moveDirection;
    private Rigidbody2D _rigidbody;
    private CollisionHandler _collisionHandler;

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

    public void Move(InputAction.CallbackContext context)
    {
        _moveDirection = context.action.ReadValue<Vector2>();
        SetFacingDirection(_moveDirection);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (_collisionHandler.IsTouching)
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }
}
