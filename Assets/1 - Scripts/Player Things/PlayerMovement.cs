using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputMap inputs;

    [SerializeField] float speed; //Movement Velocity
    private void Awake()
    {
        inputs = new InputMap();
    }

    private void OnEnable()
    {
        inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }
    private void Update()
    {
        Vector3 movementinputs = inputs.Player.Movement.ReadValue<Vector3>();
        if(movementinputs != Vector3.zero)
        {
            Vector3 position = (Vector3)transform.position + Time.deltaTime * speed * movementinputs;
            transform.position = position;
        }
    }
}
