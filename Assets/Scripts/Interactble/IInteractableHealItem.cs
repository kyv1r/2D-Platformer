public interface IInteractableHealItem
{
    public float HealPoint {  get; set; }

    public float Heal();
    public void Collect();
}
