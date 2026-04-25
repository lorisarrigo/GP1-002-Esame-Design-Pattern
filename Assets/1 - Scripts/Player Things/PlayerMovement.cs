using UnityEngine;


public class PlayerMovement : MonoBehaviour, IDamageable
{
    [SerializeField] Vector3 startingPoint;
    InputMap inputs;
    Rigidbody rb;

    public float speed; //Movement Velocity

    public float maxHP;
    [HideInInspector] public float currentHP; 

    public static PlayerMovement Instance;

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
        Vector3 movementinputs = inputs.Player.Movement.ReadValue<Vector3>();
        if (movementinputs != Vector3.zero)
        {
            Vector3 position = rb.position + Time.fixedDeltaTime * speed * movementinputs;
            rb.position = position;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
    }

    public void Despawn()
    {
        transform.position = startingPoint;
        currentHP = maxHP;
    }
}
