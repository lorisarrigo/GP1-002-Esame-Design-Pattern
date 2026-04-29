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
    UIManager UIM;
    private void Awake()
    {
        inputs = new InputMap();
        UIM = FindAnyObjectByType<UIManager>();
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
        if (GameManager.instance.state == GameState.Running)
        {
            switch (_currentAbility)
            {
                case SpeedAbility:
                    if (!speed)
                    {
                        speed = true;
                        UIM.speedBtn.color = new Color(0, 0, UIM.activeCSpeed.b);
                        StartCoroutine(StartAbility(_currentAbility));
                    }
                    break;
                case ShieldAbility:
                    if (!shield && AbilityManager.Instance.ShieldCheck)
                    {
                        shield = true;
                        UIM.shieldBtn.color = new Color(UIM.activeCShield.r, UIM.activeCShield.g, 0);
                        StartCoroutine(StartAbility(_currentAbility));
                    }
                    break;
                case MaxHPAbility:
                    if (!maxHp && AbilityManager.Instance.MaxHpCheck)
                    {
                        maxHp = true;
                        UIM.hpBtn.color = new Color(0, UIM.activeCHp.g, 0);
                        StartCoroutine(StartAbility(_currentAbility));
                    }
                    break;
                case DamageAbility:
                    if (!damage && AbilityManager.Instance.DamageCheck)
                    {
                        damage = true;
                        UIM.dmgBtn.color = new Color(UIM.activeCDmg.r, 0, UIM.activeCDmg.b);
                        StartCoroutine(StartAbility(_currentAbility));
                    }
                    break;
            }
        }
    }

    //Coroutine used to manage the duration & the cooldown of the Ability
    IEnumerator StartAbility(IAbility Ability)
    {
        Ability?.UseAbility();

        yield return new WaitForSeconds(AbilityManager.Instance.abilityDuration);

        Ability?.ResetPlayerStatus();

        yield return new WaitForSeconds(AbilityManager.Instance.abilityCooldown);
        switch (Ability)
        {
            case SpeedAbility:
                speed = false;
                UIM.speedBtn.color = new Color(0, 0, UIM.baseCSpeed.b);
                break;
            case ShieldAbility:
                shield = false;
                UIM.shieldBtn.color = new Color(UIM.baseCShield.r, UIM.baseCShield.g, 0);
                break;
            case MaxHPAbility:
                maxHp = false;
                UIM.hpBtn.color = new Color(0, UIM.baseCHp.g, 0);
                break;
            case DamageAbility:
                damage = false;
                UIM.dmgBtn.color = new Color(UIM.baseCDmg.r, 0, UIM.baseCDmg.b);
                break;
        }
    }
}
