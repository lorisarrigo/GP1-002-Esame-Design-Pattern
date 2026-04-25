using System.Collections;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField] LayerMask EnemyLayer;
    [SerializeField] float dmg;

    [SerializeField] float dmgRate;
    private void OnEnable()
    {
        StartCoroutine(DealDamage());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator DealDamage()
    {while(true)
        {
            ApplyDam();
            yield return new WaitForSeconds(dmgRate);
        }
    }
    private void ApplyDam()
    {
        Collider[] overlap = Physics.OverlapSphere(transform.position, transform.lossyScale.x/2, EnemyLayer);
        foreach (var enemyc in overlap)
        {
            if (enemyc.TryGetComponent(out IDamageable damageable))
            {
                Debug.Log("colpito");
                damageable.TakeDamage(dmg);
            }
            if(enemyc.TryGetComponent(out EnemyBehavior enemy) && enemy.currentHp <= 0 && enemy != null)
                damageable.Despawn();
        }
    }
}
