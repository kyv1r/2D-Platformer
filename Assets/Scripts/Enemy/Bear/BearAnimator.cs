using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BearAnimator : MonoBehaviour
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

    public void MoveAnimation(Enemy enemy)
    {
        _animator.SetFloat(AnimationStrings.Speed, Mathf.Abs(enemy.Rigidbody2D.velocity.x));
    }
}
