using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AbilityUser))]
public class AbilitySwitcher : MonoBehaviour
{
    InputMap inputs;
    AbilityUser abilityUser;
    IAbility ability;
    void Awake()
    {
        inputs = new InputMap();
        abilityUser = GetComponent<AbilityUser>();
    }
    void Start()
    {
        abilityUser.CurAbility = new SpeedAbility();
        ability = abilityUser.CurAbility;
    }
    void OnEnable()
    {
        inputs.Enable();
        inputs.Player.SpeedAbility.started += ActivateSpeed;
        inputs.Player.ShieldAbility.started += ActivateShield;
        inputs.Player.MaxHpAbility.started += ActivateHP;
        inputs.Player.DamageAbility.started += ActivateDam;
    }
    void OnDisable()
    {
        inputs.Disable();
        inputs.Player.SpeedAbility.started -= ActivateSpeed;
        inputs.Player.ShieldAbility.started -= ActivateShield;
        inputs.Player.MaxHpAbility.started -= ActivateHP;
        inputs.Player.DamageAbility.started -= ActivateDam;
    }
    void ActivateSpeed(InputAction.CallbackContext context)
    {
        if (ability is not SpeedAbility)
        {
            abilityUser.CurAbility = new SpeedAbility();
        }
    }
    void ActivateShield(InputAction.CallbackContext context)
    {
        if (ability is not ShieldAbility)
        {
            abilityUser.CurAbility = new ShieldAbility();
        }
    }
    void ActivateHP(InputAction.CallbackContext context)
    {
        if (ability is not MaxHPAbility)
        {
            abilityUser.CurAbility = new MaxHPAbility();
        }
    }
    void ActivateDam(InputAction.CallbackContext context)
    {
        if (ability is not DamageAbility)
        {
            abilityUser.CurAbility = new DamageAbility();
        }
    }
}
