using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _distanceRay;
    [SerializeField] private LayerMask _layerMask;

    public bool TryGetPlayerPosition(out Vector2 playerPosition)
    {
        Vector2 rayDirection = _enemy.IsFacingRight ? Vector2.right : Vector2.left;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, _distanceRay, _layerMask);

        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, rayDirection * hit.distance, Color.green);

            playerPosition = hit.point;
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, rayDirection * _distanceRay, Color.red);

            playerPosition = Vector2.zero;
            return false;
        }
    }
}
