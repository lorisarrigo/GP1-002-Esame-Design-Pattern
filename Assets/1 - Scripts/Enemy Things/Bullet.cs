using UnityEngine;
public class Bullet : MonoBehaviour
{
    //the class used to deal damage on contact to the Player & Shield
    Rigidbody rb;
    GameObject collObj;
    [SerializeField] float bSpeed, dmgPerHit, dPos; //speed, damage & despawn position of the Bullet
    public Vector3 spawnPos, despawnPos; //the starting and end point of the trajectory 

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        //when the Bullet GameObject activate set the starting point and calculate the despawn point for the trajectory
        spawnPos = transform.position;
        despawnPos = transform.position + (transform.up * dPos);
    }
    private void OnTriggerEnter(Collider other)
    {
        //ignores the damage Area so it can't Deactivate the Bullet
        collObj = other.gameObject;

        if (collObj != AbilityManager.Instance.damageArea)
            gameObject.SetActive(false);

        //differentiate the Player to the Shield so it know when to despawn the Player and when the Shield

        if (collObj == null) return;
        collObj.TryGetComponent(out IDamageable damageable);
        
        if (damageable == null) return;
        if (collObj.TryGetComponent(out ShieldArea shield))
        {
            damageable.TakeDamage(dmgPerHit);

            if (shield == null) return;
            if (AbilityManager.Instance.shieldCurrentHp <= 0)
                damageable.Despawn();
        }
        else if (collObj.TryGetComponent(out Player player))
        {
            if (AbilityManager.Instance.shieldCurrentHp <= 0)
                damageable.TakeDamage(dmgPerHit);

            if (player == null) return;
            if (player.currentHP <= 0)
                damageable.Despawn();
        }
    }

    public void FixedUpdate()
    {
        rb.linearVelocity = (transform.up * bSpeed) * Time.fixedDeltaTime;
        //if the Bullet Surpass the despawn position deactivate it
        if (Vector3.Distance(spawnPos, transform.position) >= dPos)
            gameObject.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        //Gizmo used to see where the Despawn point is
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(despawnPos, new Vector3(1, 1, 1));
    }
}
