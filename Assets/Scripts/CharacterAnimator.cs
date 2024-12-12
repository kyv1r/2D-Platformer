using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
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

    public void MoveAnimation(Rigidbody2D rigidbody2D)
    {
        _animator.SetFloat(AnimationStrings.Speed, Mathf.Abs(rigidbody2D.velocity.x));
    }
}
