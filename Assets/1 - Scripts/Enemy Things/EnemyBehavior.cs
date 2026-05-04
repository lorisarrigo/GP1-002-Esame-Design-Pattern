using UnityEngine;
public class EnemyBehavior : MonoBehaviour, IDamageable
{
    //the class used to manage how the Enemy Behavs 

    [SerializeField] ItemPooler Pooler;
    Rigidbody rb;

    [Header("Health stats")]
    [SerializeField] float maxHP;
    public float currentHp;

    [Header("Attack Area")]
    [SerializeField] float overlapScale; //the scale of the OverlapSphere
    [SerializeField] LayerMask PlayerLayer; //the mask that the Overlap needs to follow
    [SerializeField] float rotationSpeed; //the speed of the rotation of the enemy

    [Header("Bullet settings")]
    [SerializeField] Transform bulletSpawner; //the position of the bullet spawner
    [SerializeField] float bRate;
    float timer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        currentHp = maxHP;
    }
    private void FixedUpdate()
    {
        Collider[] PlayerPatrolArea = Physics.OverlapSphere(transform.position, overlapScale, PlayerLayer); //create the overlapSphere

        /*if the Overlap detect the Player:
         *  saves the coordinate of the Player position     
         *  target the Player
         *else:
         *  create a float that calculate the speed independently by the Frame
         *  sets where to rotate the Enemy
         *  and rotate the RigidBody in said coordinate
         */

        if (PlayerPatrolArea.Length > 0)
        {
            Vector3 Player = PlayerPatrolArea[0].transform.position;
            transform.LookAt(Player);
            timer += Time.deltaTime;
            if (timer >= bRate)
            {
                Pooler.GetBullet(bulletSpawner.position, bulletSpawner.rotation);
                timer = 0;
            }
        }
        else
        {
            float rotate = Time.fixedDeltaTime * rotationSpeed;
            Quaternion turn = Quaternion.Euler(0, rotate, 0);
            rb.MoveRotation(rb.rotation * turn);
            timer = 0;
        }
    }
    //the health function so the enemy can take damage and despawn
    public void TakeDamage(float damage)
    {
        currentHp -= damage;
    }
    public void Despawn()
    {
        gameObject.SetActive(false);
        GameManager.instance.EnemyCounter--; //when this counter hit 0 make the Player win
    }
    private void OnDrawGizmosSelected()
    {
        //draws a Gizmo to see the Attack area
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, overlapScale);
    }
}
