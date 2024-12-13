using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSliderView : MonoBehaviour
{
    [SerializeField] private HealthSystem _healthSystem;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();

        _slider.value = _healthSystem.CurrentValue;
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
        _slider.value = healthValue;
    }
}
