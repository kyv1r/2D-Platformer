using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Player _player;    

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
     
    private void FixedUpdate()
    {
        _animator.SetFloat(AnimationStrings.speed, Mathf.Abs(_player.Rigidbody2D.velocity.x));
    }
}
