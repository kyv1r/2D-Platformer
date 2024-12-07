using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField] protected float _value;

    public float Value => _value;

    public virtual void Collect()
    {
        gameObject.SetActive(false);
    }
}