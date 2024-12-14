using TMPro;

public class HealthTextView : HealthValueView
{
    private TextMeshProUGUI _healthText;

    private void Awake()
    {
        _healthText = GetComponent<TextMeshProUGUI>();
        Init();
    }

    protected override void Init()
    {
        base.Init();
        _healthText.text = $"{MaxHealthValue}/{HealthValue}";
    }

    protected override void SetCurrentHealthValue(float healthValue)
    {
        base.SetCurrentHealthValue(healthValue);
        _healthText.text = $"{MaxHealthValue}/{HealthValue}";
    }
}
