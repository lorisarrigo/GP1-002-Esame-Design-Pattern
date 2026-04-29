using UnityEngine;
using UnityEngine.InputSystem;

//Automatically Add the Abilityuser script to the object
[RequireComponent(typeof(AbilityUser))]
public class AbilitySwitcher : MonoBehaviour
{
    //switch the Ability selected by the inputs or the selected Icon in the UI

    InputMap inputs;
    AbilityUser abilityUser;
    IAbility Ability => abilityUser.CurAbility; //Automatically pass the Ability selected to the user
    void Awake()
    {
        inputs = new InputMap();
        abilityUser = GetComponent<AbilityUser>();
    }
    void Start()
    {
        abilityUser.CurAbility = new SpeedAbility();
    }
    void OnEnable()
    {
        inputs.Enable();
        //Inputs: Speed (1); Shield (2); MaxHp (3); Damage(4);
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
    //sets the current ability selected by the input
    void ActivateSpeed(InputAction.CallbackContext context)
    {
            ChangeToSpeed();
    }
    void ActivateShield(InputAction.CallbackContext context)
    {
        if (GameManager.instance.state == GameState.Running)
        {
            ChangeToShield();
        }
    }
    void ActivateHP(InputAction.CallbackContext context)
    {
        if (GameManager.instance.state == GameState.Running)
        {
            ChangeToHp();
        }
    }
    void ActivateDam(InputAction.CallbackContext context)
    {
        if (GameManager.instance.state == GameState.Running)
        {
            ChangeToDmg();
        }
    }

    public void ChangeToSpeed()
    {
        if (Ability is not SpeedAbility)
        {
            abilityUser.CurAbility = new SpeedAbility();
        }
    }
    public void ChangeToShield()
    {
        if (Ability is not ShieldAbility && AbilityManager.Instance.ShieldCheck)
        {
            abilityUser.CurAbility = new ShieldAbility();
        }
    }
    public void ChangeToHp()
    {
        if (Ability is not MaxHPAbility && AbilityManager.Instance.MaxHpCheck)
        {
            abilityUser.CurAbility = new MaxHPAbility();
        }
    }
    public void ChangeToDmg()
    {
        if (Ability is not DamageAbility && AbilityManager.Instance.DamageCheck)
        {
            abilityUser.CurAbility = new DamageAbility();
        }
    }
}
