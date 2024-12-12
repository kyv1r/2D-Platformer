using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2D;

    public Rigidbody2D Rigidbody2D { get; private set; }

    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log(TryGetComponent(out _rigidbody2D));
    }
}
