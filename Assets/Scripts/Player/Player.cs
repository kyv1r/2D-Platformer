using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Vector2 _moveDirection;
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _playerInput = new PlayerInput();

        _playerInput.Player.Move.performed += OnMove;
    }

    private void FixedUpdate()
    {
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
        Move();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Move()
    {
        Vector2 velocity = new Vector2(_moveDirection.x, _rigidbody.velocity.y);
        _rigidbody.velocity = velocity * _moveSpeed * Time.deltaTime;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.action.ReadValue<Vector2>();
    }
}
