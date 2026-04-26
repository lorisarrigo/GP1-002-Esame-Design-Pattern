using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityUser : MonoBehaviour
{
    //The User, Cast the ability

    InputMap inputs;

    //bools used to permit the use of multiple ability at the same time
    bool speed, shield, maxHp, damage;

    IAbility _currentAbility;
    public IAbility CurAbility { get => _currentAbility; set => _currentAbility = value; }
    private void Awake()
    {
        inputs = new InputMap();
    }

    private void OnEnable()
    {
        inputs.Enable();
        //input: Casting (space)
        inputs.Player.ActivateAbility.started += Activate;
    }
    private void OnDisable()
    {
        inputs.Disable();
        inputs.Player.ActivateAbility.started -= Activate;
    }
    //create start the Coroutine for the Ability selected
    void Activate(InputAction.CallbackContext context)
    {
        switch (_currentAbility)
        {
            case SpeedAbility:
                if (!speed)
                {
                    speed = true;
                    StartCoroutine(StartAbility(_currentAbility));
                }
                break;
            case ShieldAbility:
                if (!shield)
                {
                    shield = true;
                    StartCoroutine(StartAbility(_currentAbility));
                }
                break;
            case MaxHPAbility:
                if (!maxHp)
                {
                    maxHp = true;
                    StartCoroutine(StartAbility(_currentAbility));
                }
                break;
            case DamageAbility:
                if (!damage)
                {
                    damage = true;
                    StartCoroutine(StartAbility(_currentAbility));
                }
                break;
        }
    }

    //Coroutine used to manage the duration & the cooldown of the Ability
    IEnumerator StartAbility(IAbility Ability)
    {
        Ability?.UseAbility();

        if (Ability is not MaxHPAbility)
            yield return new WaitForSeconds(AbilityManager.Instance.abilityDuration);
        else
            yield return new WaitForSeconds(0);
        Ability?.ResetPlayerStatus();

        yield return new WaitForSeconds(AbilityManager.Instance.abilityCooldown);
        switch (Ability)
        {
            case SpeedAbility:
                speed = false;
                break;
            case ShieldAbility:
                shield = false;
                break;
            case MaxHPAbility:
                maxHp = false;
                break;
            case DamageAbility:
                damage = false;
                break;
        }
    }
}
