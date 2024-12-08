using System;

public class FirstAidKit : InteractableItem
{
    public event Action Collected;

    public override void Collect()
    {
        Collected?.Invoke();
        base.Collect();
    }
}
