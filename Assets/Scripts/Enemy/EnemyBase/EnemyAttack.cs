using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private float _attackRange = 1f;
    [SerializeField] private LayerMask _layerMaskPlayer;
    [SerializeField] private float _attackRate = 1f;

    private BearAnimator _attackAnimator;
    Coroutine _attackCoroutine;
    private bool _isAttacking;

    private void Awake()
    {
        _attackAnimator = GetComponent<BearAnimator>();
    }

    public void StartAttack()
    {
        if (_isAttacking == false)
        {
            _isAttacking = true;
            _attackCoroutine = StartCoroutine(PerformPeriodicAttack());
        }
    }

    public void StopAttack()
    {
        if (_isAttacking)
        {
            _isAttacking = false;
            StopCoroutine(_attackCoroutine);
        }
    }

    public void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_attackPosition.position, _attackRange, _layerMaskPlayer);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage(_damage);
        }
    }

    private IEnumerator PerformPeriodicAttack() 
    {
        WaitForSeconds periodicityAttack = new WaitForSeconds(_attackRate);

        while (_isAttacking)
        {
            _attackAnimator.AttackAnimation();
            Attack();
            yield return periodicityAttack;
        }
    }
}
