using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityUser : MonoBehaviour
{
    InputMap inputs;
    [SerializeField] IAbility _currentAbility;
    public IAbility CurAbility { get => _currentAbility; set => _currentAbility = value; }
    private void Awake()
    {
        inputs = new InputMap();
    }

    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.ActivateAbility.started += activate;
    }
    private void OnDisable()
    {
        inputs.Disable();
        inputs.Player.ActivateAbility.started -= activate;
    }
    void activate(InputAction.CallbackContext context)
    {
        Debug.Log("abilità attivatà");
        _currentAbility?.UseAbility();
    }
}
