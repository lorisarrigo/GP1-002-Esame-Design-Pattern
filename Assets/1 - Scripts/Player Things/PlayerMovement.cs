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
        inputs.Player.SpeedAbility.started += ActivateSpeed;
        inputs.Player.ShieldAbility.started += ActivateShield;
        inputs.Player.MaxHpAbility.started += ActivateHP;
        inputs.Player.DamageAbility.started += ActivateDam;
    }
    private void OnDisable()
    {
        inputs.Disable();
        inputs.Player.SpeedAbility.started -= ActivateSpeed;
        inputs.Player.ShieldAbility.started -= ActivateShield;
        inputs.Player.MaxHpAbility.started -= ActivateHP;
        inputs.Player.DamageAbility.started -= ActivateDam;

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
    void ActivateSpeed(InputAction.CallbackContext context)
    {
        Debug.Log("Shield attivato");
    }
    void ActivateShield(InputAction.CallbackContext context)
    {
        Debug.Log("Shield attivato");
    }
    void ActivateHP(InputAction.CallbackContext context)
    {
        Debug.Log("Max Hp attivato");
    }
    void ActivateDam(InputAction.CallbackContext context)
    {
        Debug.Log("Damage attivato");
    }
}
