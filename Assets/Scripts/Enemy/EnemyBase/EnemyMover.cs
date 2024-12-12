using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CharacterAnimator))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private Rigidbody2D _rigidbody2D;
    private CharacterAnimator _enemyAnimator;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _enemyAnimator = GetComponent<CharacterAnimator>();
    }

    private void FixedUpdate()
    {
        _enemyAnimator.MoveAnimation(Rigidbody2D);
    }

    public void Move(Vector2 direction)
    {
        _rigidbody2D.velocity = new Vector2(direction.x * _speed, _rigidbody2D.velocity.y);
    }
}
