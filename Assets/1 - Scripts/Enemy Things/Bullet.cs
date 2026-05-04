using UnityEngine;
public class Bullet : MonoBehaviour
{
    //the class used to deal damage on contact to the Player or Shield

    Rigidbody rb;
    GameObject collObj;
    [SerializeField] float bSpeed, baseDmg, dmgPerHit, dPos; //speed, damage & despawn position of the Bullet
    public Vector3 spawnPos, despawnPos; //the starting and end point of the trajectory 

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        dmgPerHit = baseDmg;
    }
    private void OnEnable()
    {
        //when the Bullet GameObject activate set the starting point and calculate the despawn point for the trajectory
        spawnPos = transform.position;
        despawnPos = transform.position + (transform.up * dPos);
    }
    private void OnTriggerEnter(Collider other)
    {
        //ignores the damage & shield Area so they can't Deactivate the Bullet
        collObj = other.gameObject;

        if (collObj != AbilityManager.Instance.damageArea && collObj != AbilityManager.Instance.shieldArea)
            gameObject.SetActive(false);

        //when the bullet hit an Object checks if it has the Interface and the script so it can deal Damage to the Player

        if (collObj == null) return;
        collObj.TryGetComponent(out IDamageable damageable);
        collObj.TryGetComponent(out Player player);

        if (damageable == null) return;
        damageable.TakeDamage(dmgPerHit);

        //checks if the Player or the shield has no more HP 
        if (player == null) return;
        if (player.currentHP <= 0 || player.shieldCurrentHp <= 0 && AbilityManager.Instance.shieldArea.activeInHierarchy)
            damageable.Despawn();
    }

    public void FixedUpdate()
    {
        rb.linearVelocity = (transform.up * bSpeed) * Time.fixedDeltaTime;
        //if the Bullet Surpass the despawn position deactivate it
        if (Vector3.Distance(spawnPos, transform.position) >= dPos)
            gameObject.SetActive(false);

        //if the MaxHp Ability is Active makes the Player invincible
        if (AbilityManager.Instance.invincible)
            dmgPerHit = 0;
        else
            dmgPerHit = baseDmg;
    }
    private void OnDrawGizmos()
    {
        //Gizmo used to see where the Despawn point is
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(despawnPos, new Vector3(1, 1, 1));
    }
}
