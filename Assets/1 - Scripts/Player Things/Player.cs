using UnityEngine;
public class Player : MonoBehaviour, IDamageable
{
    //The Player, it manages its movement and velocity

    /*it's recalled in:
     * UIManager to Update the HUD fillbar;
     * Bullet so it can deal damage;
     * AbilityPickUp to checks if the Player collides with it; 
     * AbilityManager so it can set the base Speed for the SpeedUp Ability;
     * MaxHPAbility to refill the currentHP;
     * SpeedAbility to momentarily change the Speed variable
     */

    [Header("Movement")]
    public float speed; //used to calculate the Movement Velocity
    Vector3 startingPoint; //used to set the Starting point at the start
    InputMap inputs; //gets the Input map
    Rigidbody rb;

    [Header("Health")]
    public float maxHP; //the Maximum amount of health
    [HideInInspector] public float currentHP; //the current amount

    public static Player Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        inputs = new InputMap();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //sets the starting health and point 
        startingPoint = transform.position;
        currentHP = maxHP;
    }
    private void OnEnable()
    {
        inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }
    private void FixedUpdate()
    {
        #region Movement
        //takes the inputs, calculate the next position to set in the RigidBody
        Vector3 movementinputs = inputs.Player.Movement.ReadValue<Vector3>();
        if (movementinputs != Vector3.zero)
        {
            Vector3 position = rb.position + Time.fixedDeltaTime * speed * movementinputs;
            rb.position = position;
        }
        #endregion
    }

    public void TakeDamage(float damage)
    {
        //everytime a bullet hit the Player takes the damage and subtract it to the curren health
        currentHP -= damage;
    }

    public void Despawn()
    {
        //when the Player dies repositions it at the starting point and refill the health 
        transform.position = startingPoint;
        currentHP = maxHP;
    }
}
