using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _distanceRay;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _radiusDetect;

    public bool TryFindPlayerPosition(out Vector2 playerPosition)
    {
        Collider2D[] players = Physics2D.OverlapCircleAll(transform.position, _radiusDetect, _layerMask);

        if (players.Length == 0)
        {
            playerPosition = Vector2.zero;
            return false;
        }

        foreach (var player in players)
        {
            playerPosition = player.transform.position;
            return true;
        }

        playerPosition = Vector2.zero;
        return false;
    }
}
