using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private InteractableItemCollector _interactableItemCollector;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private HealthSystem _healthSystem;
    [SerializeField] private float _countCoin;

    public Rigidbody2D Rigidbody2D { get; private set; }

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _interactableItemCollector.Collected += OnItemCollected;
    }

    private void OnDisable()
    {
        _interactableItemCollector.Collected -= OnItemCollected;
    }

    private void OnItemCollected(float value, InteractableItem item)
    {
        if (item is Coin)
        {
            TransferCoin(value);
        }
        else if (item is FirstAidKit)
        {
            Heal(value);
        }
    }

    private void TransferCoin(float coinValue)
    {
        _countCoin += coinValue;
    }

    private void Heal(float healPoint)
    {
        _healthSystem.Heal(healPoint);
    }
}
