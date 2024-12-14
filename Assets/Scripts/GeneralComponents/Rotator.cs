using UnityEngine;

public class Rotator : MonoBehaviour
{
    private bool _isFacingRight = true;

    public bool IsFacingRight
    {
        get
        {
            return _isFacingRight;
        }
        set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
                _isFacingRight = value;
            }
        }
    }

    public void SetFacingDirection(Vector2 direction)
    {
        if (direction.x > 0 && IsFacingRight == false)
            IsFacingRight = true;
        else if (direction.x < 0 && IsFacingRight)
            IsFacingRight = false;
    }

    public void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
