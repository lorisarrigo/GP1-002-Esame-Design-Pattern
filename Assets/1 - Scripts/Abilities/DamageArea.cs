using System.Collections;
using UnityEngine;
public class DamageArea : MonoBehaviour
{
    //The class used to deal damage at the Enemies 

    [SerializeField] float dmg, dmgRate;

    GameObject collObj;
    private void OnTriggerStay(Collider other)
    {
        collObj = other.gameObject;
    }
    private void OnEnable()
    {
        StartCoroutine(DealDamage());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    //this coroutine does damage without a timer, the Coroutine itself is the timer
    IEnumerator DealDamage()
    {
        while (true)
        {
            ApplyDam();
            yield return new WaitForSeconds(dmgRate);
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
