using System;

public class Cake : InteractableItem
{
    public event Action Collected;

    public override void Collect()
    {
        Collected?.Invoke();
        base.Collect();
    }
}
