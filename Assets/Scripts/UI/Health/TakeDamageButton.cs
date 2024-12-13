using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TakeDamageButton : MonoBehaviour
{
    [SerializeField] private HealthSystem _healthSystem;

    private float _damageValue = 5;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(TakeDamage);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TakeDamage);
    }

    private void TakeDamage()
    {
        _healthSystem.TakeDamage(_damageValue);
    }
}
