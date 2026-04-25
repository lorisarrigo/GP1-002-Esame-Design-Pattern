using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    GameObject collObj;
    [SerializeField] float bSpeed, dmgPerHit, dPos;
    public Vector3 startPos, despawnPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        startPos = transform.position;
        despawnPos = transform.position + (transform.up * dPos);
    }
    private void OnTriggerEnter(Collider other)
    {
        collObj = other.gameObject;
        DmgOnHit();
        if(AbilityManager.Instance.shieldCurrentHp > 0)
            DmgShield();
        if (collObj != AbilityManager.Instance.damageArea)
            gameObject.SetActive(false);
    }

    public void FixedUpdate()
    {
        rb.linearVelocity = (transform.up * bSpeed) * Time.fixedDeltaTime;
        if (Vector3.Distance(startPos, transform.position) >= dPos)
            gameObject.SetActive(false);
    }
    public void DmgOnHit()
    {
        if (collObj == null) return;
        collObj.TryGetComponent(out IDamageable damageable);
        collObj.TryGetComponent(out PlayerMovement player);

        if (damageable == null) return;
        if (AbilityManager.Instance.shieldCurrentHp <= 0)
            damageable.TakeDamage(dmgPerHit);

        if (player == null) return;
        if (player.currentHP <= 0)
            damageable.Despawn();
    }
    public void DmgShield()
    {
        if (collObj == null) return;
        collObj.TryGetComponent(out IDamageable damageable);
        collObj.TryGetComponent(out ShieldArea shield);

        if (damageable == null) return;
        damageable.TakeDamage(dmgPerHit);

        if (shield == null) return;
        if (AbilityManager.Instance.shieldCurrentHp <= 0)
            damageable.Despawn();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(despawnPos, new Vector3(1, 1, 1));
    }
}
