using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMovement _playerMovement;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerMovement.Attacked += AttackAnimation;
    }

    private void OnDisable()
    {
        _playerMovement.Attacked -= AttackAnimation;
    }

    private void Update()
    {
        _animator.SetFloat(AnimationStrings.speed, Mathf.Abs(_player.Rigidbody2D.velocity.x));
    }

    private void AttackAnimation()
    {
        _animator.SetTrigger(AnimationStrings.attack);
    }
}
