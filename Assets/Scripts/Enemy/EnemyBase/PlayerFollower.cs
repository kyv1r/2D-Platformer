using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class PlayerFollower : MonoBehaviour
{
    private EnemyMover _enemyMover;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    public void FollowPlayer(Vector2 playerPosition)
    {
        Vector2 direction = playerPosition - (Vector2)transform.position;
        _enemyMover.Move(direction);
    }
}
