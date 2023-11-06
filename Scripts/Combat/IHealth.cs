public interface IHealth
{
    int MaxHealth { get; }
    float CurrHealth { get; }

    void TakeDamage(float amount);
    void Heal(float amount);
}
