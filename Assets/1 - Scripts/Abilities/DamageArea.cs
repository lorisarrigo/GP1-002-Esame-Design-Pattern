using System.Collections;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField] LayerMask EnemyLayer;
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
            yield return new WaitForSeconds(0.9f);
        }
    }
    private void ApplyDam()
    {
        Collider[] overlap = Physics.OverlapSphere(transform.position, transform.lossyScale.x/2, EnemyLayer);
        foreach (var enemy in overlap)
        {
            Debug.Log("Damaged");
        }
    }
}
