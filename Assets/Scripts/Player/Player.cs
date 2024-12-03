using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private CoinCollector _coinCollector;
    [SerializeField] private int _countCoin;

    public bool _isFacingRight = true;
    private bool _isGround = false;
    private Vector2 _moveDirection;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

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
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _coinCollector.FindedCoin += CollectCoin;
    }

    private void OnDisable()
    {
        _coinCollector.FindedCoin -= CollectCoin;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_moveDirection.x * _moveSpeed, _rigidbody.velocity.y);
        _animator.SetFloat("speed", Mathf.Abs(_rigidbody.velocity.x));
    }

    private void CollectCoin()
    {
        _countCoin++;
    }

    private void SetFacingDirection(Vector2 direction)
    {
        if(direction.x > 0 && IsFacingRight == false)
            IsFacingRight = true;
        else if (direction.x < 0 && IsFacingRight)
            IsFacingRight = false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.action.ReadValue<Vector2>();
        SetFacingDirection(_moveDirection);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (_isGround)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            _isGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IToucheable>(out IToucheable groundable))
            _isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IToucheable>(out IToucheable groundable))
            _isGround = false;
    }
}
