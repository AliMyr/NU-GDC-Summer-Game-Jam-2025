public interface IHealth
{
    void TakeDamage(float amount);
    float CurrentHealth { get; }
    bool IsAlive { get; }
}
