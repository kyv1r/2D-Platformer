using System;
using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private float _attackRange = 1f;
    [SerializeField] private LayerMask _layerMaskPlayer;
    [SerializeField] private float _attackRate = 1f;

    private bool _isAttacking;

    public event Action Attacked;

    public void StartAttack()
    {
        if (_isAttacking == false)
        {
            _isAttacking = true;
            StartCoroutine(WaitForNextAttack());
        }
    }

    public void StopAttack()
    {
        if (_isAttacking)
        {
            _isAttacking = false;
            StopCoroutine(WaitForNextAttack());
        }
    }

    public void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_attackPosition.position, _attackRange, _layerMaskPlayer);

        foreach (var collider in colliders)
        {
            collider.GetComponent<IDamageable>()?.TakeDamage(_damage);
        }
    }

    private IEnumerator WaitForNextAttack()
    {
        WaitForSeconds periodicityAttack = new WaitForSeconds(_attackRate);

        while (_isAttacking)
        {
            Attack();
            Attacked?.Invoke();
            yield return periodicityAttack;
        }
    }
}
