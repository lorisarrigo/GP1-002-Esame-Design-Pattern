using System;
using UnityEngine;
public class Player : MonoBehaviour, IDamageable
{
    //The Player, it manages its movement and Health

    [Header("Movement")]
    Vector3 startingPoint; //used to set the Starting point of the Player
    Rigidbody rb;
    InputMap inputs; //gets the Input map
    public float speed;

    [Header("Health")]
    public float maxHP; //the Max health Points
    public float maxShieldP; //the Max Shield Points (SP)
    [HideInInspector] public float currentHP, shieldCurrentHp; //the current values that Update on every hit
    public static event Action OnDamage; //an action invoked when the Player gets hit (used by the HP & SP)

    public static Player Instance;
    /*it's recalled in:
     * UIManager to Update the HP/SP fillbars;
     * Bullet so it can deal damage;
     * AbilityPickUp to checks if the Player collides with it; 
     * AbilityManager so it can set the base Speed for the SpeedUp Ability;
     * SpeedAbility to momentarily change the Speed variable;
     * ShieldAbility to fill/defill the SP;
     * MaxHPAbility to refill the currentHP;
     */

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

    //sets the starting point and starting health 
    private void Start()
    {
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

    /*In this class the FixedUpdate does:
     * 1- set the movement inèut to a vector3 local variable
     * 2- calculate the next position in which the Player will move
     * 3- sets it to the current position of the Player so it moves
     */
    private void FixedUpdate()
    {
        //1.
        Vector3 movementinputs = inputs.Player.Movement.ReadValue<Vector3>();
        if (movementinputs != Vector3.zero)
        {
            //2.
            Vector3 position = rb.position + Time.fixedDeltaTime * speed * movementinputs;
            //3.
            rb.position = position;
        }
    }

    //everytime a bullet hit the Player takes the damage and subtract it to the HPs or the SP
    public void TakeDamage(float damage)
    {
        if (AbilityManager.Instance.shieldArea.activeInHierarchy)
        {
            shieldCurrentHp -= damage;
            OnDamage?.Invoke(); //Invoke the event Action so it Update the Shieldbar
        }
        else
        {
            currentHP -= damage;
            OnDamage?.Invoke(); //Invoke the event Action so it Update the healthBar
        }
    }

    //if the shield is Active in the hierarchy and the Player has no more SP, deactivate the Shield
    //else, teleport it at the starting position, refill the HPs, force the damage Area to deactive & Recall the Undo to lose the Last Ability taken
    public void Despawn()
    {
        if (AbilityManager.Instance.shieldArea.activeInHierarchy)
            AbilityManager.Instance.shieldArea.SetActive(false);
        else
        {
            transform.position = startingPoint;
            currentHP = maxHP;
            AbilityManager.Instance.damageArea.SetActive(false);
            AbilityCommand.Instance.UndoCommand();
        }
    }
}