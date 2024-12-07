using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _distanceRay;
    [SerializeField] private LayerMask _layerMask;

    private bool _isPlayerDetected;
    private Vector2 _playerPosition;

    public bool IsPlayerDetected => _isPlayerDetected;

    public Vector2 GetPlayerPosition()
    {
        Collider2D[] players = Physics2D.OverlapCircleAll(transform.position, 2f, _layerMask);

        foreach (var player in players)
        {
            _isPlayerDetected = true;
            _playerPosition = player.transform.position;
        }

        if(players.Length == 0)
        {
            _isPlayerDetected = false;
        }

        return _playerPosition;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }
}
