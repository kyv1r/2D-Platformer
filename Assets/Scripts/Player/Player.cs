using UnityEngine;

[RequireComponent(typeof(InteractableItemCollector))]
[RequireComponent(typeof(Wallet) ,typeof(PlayerAttack))]
public class Player : MonoBehaviour
{
    [SerializeField] private InteractableItemCollector _interactableItemCollector;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Health _health;
    private Wallet _wallet;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _wallet = GetComponent<Wallet>();
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
        _wallet.AddMoney(coinValue);
    }

    private void Heal(float healPoint)
    {
        _health.Heal(healPoint);
    }
}
