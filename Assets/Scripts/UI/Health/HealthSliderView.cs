using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSliderView : HealthValueView
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        Init();
    }

    protected override void Init()
    {
        base.Init();
        _slider.value = HealthValue;
    }

    protected override void SetCurrentHealthValue(float healthValue)
    {
        base.SetCurrentHealthValue(healthValue);
        _slider.value = HealthValue;

    }
}
