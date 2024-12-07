using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _distanceRay;
    [SerializeField] private LayerMask _layerMask;

    public bool HasGroundBelow()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, _distanceRay, _layerMask);
        return hit.collider != null;
    }
}
