using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class AreaPatroller : MonoBehaviour
{
    private EnemyMover _enemyMover;

    private Vector2 _moveDirectionX;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    public void PatrolArea()
    {
        float localScaleX = Mathf.Sign(transform.localScale.x);

        _moveDirectionX = new Vector2(localScaleX, 0);

        _enemyMover.Move(_moveDirectionX);
    }
}
