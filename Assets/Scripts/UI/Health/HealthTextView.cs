using TMPro;
using UnityEngine;

public class HealthTextView : MonoBehaviour
{
    [SerializeField] private HealthSystem _healthSystem;

    private TextMeshProUGUI _healthText;

    private void Awake()
    {
        _healthText = GetComponent<TextMeshProUGUI>();

        _healthText.text = $"{_healthSystem.MaxValue}/{_healthSystem.CurrentValue}";
    }

    private void OnEnable()
    {
        _healthSystem.HealthChanged += SetCurrentHealthValue;
    }

    private void OnDisable()
    {
        _healthSystem.HealthChanged -= SetCurrentHealthValue;
    }

    private void SetCurrentHealthValue(float healthValue)
    {
        _healthText.text = $"{_healthSystem.MaxValue}/{healthValue}";
    }
}
