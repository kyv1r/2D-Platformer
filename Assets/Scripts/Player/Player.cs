using UnityEngine;

[RequireComponent(typeof(InteractableItemCollector), typeof(AbilityUser))]
[RequireComponent(typeof(Wallet) ,typeof(PlayerAttacker))]
public class Player : MonoBehaviour
{
    [SerializeField] private InteractableItemCollector _interactableItemCollector;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Health _health;
    private Wallet _wallet;
    private AbilityUser _abiltyUser;

    private void Awake()
    {
        _abiltyUser = GetComponent<AbilityUser>();
        _health = GetComponent<Health>();
        _wallet = GetComponent<Wallet>();
    }

    private void OnEnable()
    {
        _interactableItemCollector.Collected += OnItemCollected;
        _abiltyUser.PulledHealth += Heal;
    }

    private void OnDisable()
    {
        _interactableItemCollector.Collected -= OnItemCollected;
        _abiltyUser.PulledHealth -= Heal;
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
