using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void AttackAnimation()
    {
        _animator.SetTrigger(AnimationStrings.Attack);
    }

    public void MoveAnimation(PlayerMover player)
    {
        _animator.SetFloat(AnimationStrings.Speed, Mathf.Abs(player.Rigidbody2D.velocity.x));
    }
}
