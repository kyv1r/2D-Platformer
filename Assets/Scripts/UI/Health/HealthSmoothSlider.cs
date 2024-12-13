using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSmoothSlider : MonoBehaviour
{
    [SerializeField] private HealthSystem _healthSystem;

    private Slider _slider;
    private Coroutine _coroutine;

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
        _coroutine = StartCoroutine(SmoothChangeHealthValue(healthValue));
    }

    private IEnumerator SmoothChangeHealthValue(float healthValue)
    {
        while (_slider.value != healthValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, healthValue, 0.09f);
            yield return null;
        }

        if(_slider.value != healthValue)
            yield break;
    }
}
