using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    InputMap inputs;
    Rigidbody rb;
    public float speed; //Movement Velocity

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
        rb =GetComponent<Rigidbody>();
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
        if(movementinputs != Vector3.zero)
        {
            Vector3 position = rb.position + Time.fixedDeltaTime * speed * movementinputs;
            rb.position = position;
        }
    }

}
