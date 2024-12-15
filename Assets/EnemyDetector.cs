using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyDetector : MonoBehaviour
{
    private CircleCollider2D _circleCollider2D;

    public CircleCollider2D CircleCollider2D => _circleCollider2D;

    private void Awake()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }
}
