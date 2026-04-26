using UnityEngine;
public class ShieldArea : MonoBehaviour, IDamageable
{
    //the Class is used to asign the damage to the shield
    public void TakeDamage(float damage)
    {
        AbilityManager.Instance.shieldCurrentHp -= damage;
    }
    public void Despawn()
    {
        gameObject.SetActive(false);
    }
}
