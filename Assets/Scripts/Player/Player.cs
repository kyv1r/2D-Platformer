using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private InteractableItemCollector _interactableItemCollector;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private int _countCoin;

    private Rigidbody2D _rigidbody2D;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _interactableItemCollector.Healed += Heal;
    }

    private void OnDisable()
    {
        _interactableItemCollector.Healed -= Heal;
    }

    private void Update()
    {
        TransferCoin();
    }

    private void TransferCoin()
    {
        _countCoin = _interactableItemCollector.CountCoin;
    }

    private void Heal()
    {
        _playerMovement.Health += _interactableItemCollector.HealPoint;
    }
}
