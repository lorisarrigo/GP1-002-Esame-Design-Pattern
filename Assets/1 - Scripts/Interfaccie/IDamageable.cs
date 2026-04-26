public interface IDamageable
{
    //This interface is used by the Bullets to deal damage to the Plyer and the Shield
    //olso used by the Damage Area to deal damage to the enemies
    public void TakeDamage(float damage);
    public void Despawn();
}
