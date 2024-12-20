using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(CollisionHandler), typeof(PlayerInput))]
[RequireComponent(typeof(Rotator), typeof(CharacterAnimator), typeof(Health))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Rotator _facing;
    private CollisionHandler _collisionHandler;
    private PlayerInput _playerInput;
    private CharacterAnimator _playerAnimator;
    private Health _health;

    public bool _isFacingRight = true;
    private bool _jumpRequested = false;

    private Vector2 _moveDirection;
    private Rigidbody2D _rigidbody2D;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collisionHandler = GetComponent<CollisionHandler>();
        _facing = GetComponent<Rotator>();
        _playerAnimator = GetComponent<CharacterAnimator>();
        _health = GetComponent<Health>();

        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();

        _playerInput.Player.Move.performed += OnMove;
        _playerInput.Player.Move.canceled += OnMove;

        _playerInput.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        _playerInput.Disable();

        _playerInput.Player.Move.performed -= OnMove;
        _playerInput.Player.Move.canceled -= OnMove;

        _playerInput.Player.Jump.performed -= OnJump;
    }

    private void FixedUpdate()
    {
        if(_health.IsDie == false)
        {
            _rigidbody2D.velocity = new Vector2(_moveDirection.x * _moveSpeed, _rigidbody2D.velocity.y);

            if (_jumpRequested)
            {
                if (_collisionHandler.IsTouching)
                    _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);

                _jumpRequested = false;
            }
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
        
    }

    private void Update()
    {
        _playerAnimator.PlayMove(Rigidbody2D);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.action.ReadValue<Vector2>();
        _facing.SetFacingDirection(_moveDirection);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            _jumpRequested = true;
    }
}
