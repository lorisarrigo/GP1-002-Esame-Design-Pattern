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
        inputs.Player.ShieldAbility.performed += ActivateShield;
        inputs.Player.MaxHpAbility.performed += ActivateHP;
        inputs.Player.DamageAbility.performed += ActivateDam;
    }
    private void OnDisable()
    {
        inputs.Disable();
        inputs.Player.ShieldAbility.performed -= ActivateShield;
        inputs.Player.MaxHpAbility.performed -= ActivateHP;
        inputs.Player.DamageAbility.performed -= ActivateDam;

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
