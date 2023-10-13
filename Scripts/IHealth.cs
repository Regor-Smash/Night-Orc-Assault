public interface IHealth
{
    int MaxHealth { get; }
    float CurrHealth { get; }

    void TakeDamage(int amount);
    void Heal(int amount);
}
