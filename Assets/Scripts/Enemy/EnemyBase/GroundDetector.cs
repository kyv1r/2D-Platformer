using System.Collections;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _distanceRay;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _checkInterval = 0.001f;

    public bool HasGroundBelow { get; private set; }

    private void Start()
    {
        StartCoroutine(CheckGroundCoroutine());
    }

    public bool HasGroundForward()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, _distanceRay, _layerMask);
        return hit.collider != null;
    }

    private IEnumerator CheckGroundCoroutine()
    {
        while (enabled)
        {
            HasGroundBelow = HasGroundForward();
            yield return new WaitForSeconds(_checkInterval);
        }
    }

}
