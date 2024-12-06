using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _distanceRay;
    [SerializeField] private LayerMask _layerMask;

    private bool _isPlayerDetected;
    private Vector2 _playerDirection;

    public bool IsPlayerDetected => _isPlayerDetected;

    public Vector2 GetPlayerPosition()
    {
        Collider2D[] players = Physics2D.OverlapCircleAll(transform.position, 2f, _layerMask);

        foreach (var player in players)
        {
            Debug.Log(player.name);
            _isPlayerDetected = true;
            _playerDirection = (player.transform.position - transform.position).normalized;

            if(player == null)
                _isPlayerDetected = false;
        }

        return _playerDirection;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }
}
