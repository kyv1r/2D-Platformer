using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class AreaPatroler : MonoBehaviour
{
    private EnemyMover _enemyMover;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    public void PatrolArea()
    {
        float moveDirection = Mathf.Sign(transform.localScale.x);
        _enemyMover.Move(new Vector2(moveDirection, 0));
    }
}
