public interface IDamageable
{
    float Health { get; set; }
    float MaxHealth { get; set; }
    float MinHealth { get; set; }
    float Damage { get; set; }

    public void TakeDamage(float damage);
    public void Attack();
}
