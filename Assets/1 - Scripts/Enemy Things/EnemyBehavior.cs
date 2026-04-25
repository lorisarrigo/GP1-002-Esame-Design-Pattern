using UnityEngine;

public class EnemyBehavior : MonoBehaviour, IDamageable
{
    Rigidbody rb; //sets the Rigidbody variable

    [SerializeField] float maxHP;
    public float currentHp;

    [SerializeField] float overlapScale; //the scale of the OverlapSphere
    [SerializeField] LayerMask PlayerLayer; //the mask that the Overlap needs to follow
    [SerializeField] float rotationSpeed; //the speed of the rotation of the enemy

    [SerializeField] Transform bulletSpawner;
    public GameObject bullet;
    public float bRate;
    float timer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //gets the rigidbody
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

        if (PlayerPatrolArea.Length > 0 )
        {
            Vector3 Player = PlayerPatrolArea[0].transform.position;
            transform.LookAt(Player);
            timer += Time.deltaTime;
            if (timer >= bRate)
            {
                Instantiate(bullet, bulletSpawner.position, bulletSpawner.rotation);
                timer = 0;
            }
        }
        else
        {
            float rotate = Time.fixedDeltaTime * rotationSpeed;
            Quaternion turn = Quaternion.Euler(0, rotate, 0);
            rb.MoveRotation(rb.rotation * turn);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHp -= damage;
    }
    public void Despawn()
    {
        gameObject.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        //draws a Gizmo to see the traking area
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, overlapScale);
    }
}
