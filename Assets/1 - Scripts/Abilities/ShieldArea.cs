using UnityEngine;

public class ShieldArea : MonoBehaviour, IDamageable
{
    public void TakeDamage(float damage)
    {
        AbilityManager.Instance.shieldCurrentHp -= damage;
    }
    public void Despawn()
    {
        gameObject.SetActive(false);
    }

}
