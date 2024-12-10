using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _distanceRay;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _radiusDetect;

    private bool _isPlayerDetected;
    private Vector2 _playerPosition;

    public bool IsPlayerDetected => _isPlayerDetected;

    public Vector2 FindPlayerPosition()
    {
        Collider2D[] players = Physics2D.OverlapCircleAll(transform.position, _radiusDetect, _layerMask);

        if (players.Length == 0)
            _isPlayerDetected = false;

        foreach (var player in players)
        {
            _isPlayerDetected = true;
            _playerPosition = player.transform.position;
            return _playerPosition;
        }

        return _playerPosition;
    }
}
