using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Manages the element in the HUD of the Player

    [Header("Health & Shield bars")]
    public Image healthBar;
    public Image shieldBar;

    [Header("Ability icons")]
    [SerializeField] GameObject shieldIcon;
    [SerializeField] GameObject maxHpIcon;
    [SerializeField] GameObject damageIcon;

    [Header("Speed Btn")]
    public Image speedBtn;
    public Color baseCSpeed;
    public Color activeCSpeed;

    [Header("Shield Btn")]
    public Image shieldBtn;
    public Color baseCShield;
    public Color activeCShield;

    [Header("MaxHp Btn")]
    public Image hpBtn;
    public Color baseCHp;
    public Color activeCHp;

    [Header("damage Btn")]
    public Image dmgBtn;
    public Color baseCDmg;
    public Color activeCDmg;

    private void OnEnable()
    {
        //health & shield bars functions
        Player.OnDamage += UpdateBars;
        ShieldAbility.OnShield += UpdateBars;
        MaxHPAbility.OnMaxHp += UpdateBars;
        //ability icons functions
        ChangeStatusCommand.OnShield += ShieldIcon;
        ChangeStatusCommand.OnHp += HpIcon;
        ChangeStatusCommand.OnDmg += DmgIcon;
    }
    private void OnDisable()
    {
        //health & shield bars functions
        Player.OnDamage -= UpdateBars;
        ShieldAbility.OnShield -= UpdateBars;
        MaxHPAbility.OnMaxHp -= UpdateBars;
        //ability icons functions
        ChangeStatusCommand.OnShield -= ShieldIcon;
        ChangeStatusCommand.OnHp -= HpIcon;
        ChangeStatusCommand.OnDmg -= DmgIcon;
    }
    //Updates the 2 Bars of the Player
    private void UpdateBars()
    {
        healthBar.fillAmount = (float)Player.Instance.currentHP / (float)Player.Instance.maxHP;
        shieldBar.fillAmount = (float)Player.Instance.shieldCurrentHp / (float)Player.Instance.maxShieldP;
    }

    //The next 3 function are used to activate the Abilities BTNs 
    private void ShieldIcon()
    {
        if (AbilityManager.Instance.ShieldCheck)
            shieldIcon.SetActive(true);
        else
            shieldIcon.SetActive(false);
    }
    private void HpIcon()
    {
        if (AbilityManager.Instance.MaxHpCheck)
            maxHpIcon.SetActive(true);
        else
            maxHpIcon.SetActive(false);
    }
    private void DmgIcon()
    {
        if (AbilityManager.Instance.DamageCheck)
            damageIcon.SetActive(true);
        else
            damageIcon.SetActive(false);
    }
}
