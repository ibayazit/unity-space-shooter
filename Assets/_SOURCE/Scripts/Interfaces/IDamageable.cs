public interface IDamageable
{
    int Health { get; set; }

    void Damage(int damageAmount);
    void Die();
}
