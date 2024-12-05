using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _distanceRay;
    [SerializeField] private LayerMask _layerMask;

    public bool CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, _distanceRay, _layerMask);

        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.green);
            return true; 
        }
        else
        {
            Debug.DrawRay(transform.position, -transform.up * _distanceRay, Color.red);
            return false;
        }
    }
}
