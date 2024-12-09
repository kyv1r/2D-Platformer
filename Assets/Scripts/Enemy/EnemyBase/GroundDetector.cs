using System.Collections;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _distanceRay;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _checkInterval = 0.001f;

    private bool _hasGroundBelow;
    public bool HasGroundBelow => _hasGroundBelow;

    private void Start()
    {
        StartCoroutine(CheckGroundCoroutine());
    }

    private IEnumerator CheckGroundCoroutine()
    {
        while (enabled)
        {
            _hasGroundBelow = PerformGroundCheck();
            yield return new WaitForSeconds(_checkInterval);
        }
    }

    public bool PerformGroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, _distanceRay, _layerMask);
        return hit.collider != null;
    }
}
