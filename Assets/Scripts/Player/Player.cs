using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InteractableItemCollector), typeof(PlayerAnimator))]
[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour
{
    [SerializeField] private InteractableItemCollector _interactableItemCollector;
    [SerializeField] private float _moveSpeed;  
    [SerializeField] private float _jumpForce;

    private HealthSystem _healthSystem;
    private Wallet _wallet;
    private PlayerAnimator _playerAnimator;

    public Rigidbody2D Rigidbody2D { get; private set; }

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        _healthSystem = GetComponent<HealthSystem>();
        _wallet = GetComponent<Wallet>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void OnEnable()
    {
        _interactableItemCollector.Collected += OnItemCollected;
    }

    private void OnDisable()
    {
        _interactableItemCollector.Collected -= OnItemCollected;
    }

    private void Update()
    {
        _playerAnimator.MoveAnimation(this);
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
        _wallet.AddMoney(coinValue);
    }

    private void Heal(float healPoint)
    {
        Debug.Log("ASDASD");

        _healthSystem.Heal(healPoint);
    }
}
