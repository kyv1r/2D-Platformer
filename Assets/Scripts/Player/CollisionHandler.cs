using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public bool IsTouching { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IToucheable>(out IToucheable toucheable))
        {
            IsTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IToucheable>(out IToucheable toucheable))
        {
            IsTouching = false;
        }
    }
}
