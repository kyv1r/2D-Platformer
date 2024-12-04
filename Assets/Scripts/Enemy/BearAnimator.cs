using UnityEngine;

public class BearAnimator : MonoBehaviour
{
    [SerializeField] private Bear _bear;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _animator.SetFloat(AnimationStrings.speed, Mathf.Abs(_bear.Rigidbody2D.velocity.x));
    }
}
