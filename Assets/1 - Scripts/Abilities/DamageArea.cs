using UnityEngine;
public class DamageArea : MonoBehaviour
{
    //The class used to deal damage at the Enemies 

    [SerializeField] float dmg, dmgRate, timer;

    GameObject collObj;
    private void OnDisable()
    {
        timer = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        collObj = other.gameObject;
        timer += Time.deltaTime;
        if (timer >= dmgRate)
        {
            ApplyDam();
            timer = 0;
        }
    }

    private void ApplyDam()
    {
        if (collObj == null) return;
        collObj.TryGetComponent(out IDamageable damageable);
        collObj.TryGetComponent(out EnemyBehavior enemy);

        if (damageable == null) return;
        damageable.TakeDamage(dmg);

        if (enemy == null) return;
        if (enemy.currentHp <= 0)
            damageable.Despawn();
    }
}
