using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputMap inputs;
    Rigidbody rb;
    [SerializeField] float speed; //Movement Velocity
    private void Awake()
    {
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
