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

    public void MoveAnimation(Character character)
    {
        _animator.SetFloat(AnimationStrings.Speed, Mathf.Abs(character.Rigidbody2D.velocity.x));
    }
}
