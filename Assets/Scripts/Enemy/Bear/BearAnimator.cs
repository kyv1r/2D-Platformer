using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BearAnimator : MonoBehaviour
{
    [SerializeField] private Bear _bear;
    [SerializeField] private EnemyAttack _enemyAttack;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _enemyAttack.Attacked += AttackAnimation;
    }

    private void OnDisable()
    {
        _enemyAttack.Attacked -= AttackAnimation;
    }

    private void FixedUpdate()
    {
        _animator.SetFloat(AnimationStrings.speed, Mathf.Abs(_bear.Rigidbody2D.velocity.x));
    }

    private void AttackAnimation()
    {
        _animator.SetTrigger(AnimationStrings.attack);
    }
}
