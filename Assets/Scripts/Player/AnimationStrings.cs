using UnityEngine;

internal class AnimationStrings : MonoBehaviour
{
    internal static int Speed = Animator.StringToHash(nameof(Speed));
    internal static int Attack = Animator.StringToHash(nameof(Attack));
}
