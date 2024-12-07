using System;

public class Coin : InteractableItem
{
    public event Action Collected;

    public override void Collect()
    {
        Collected?.Invoke();
        base.Collect();
    }
}
