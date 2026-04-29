using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Manages the element in the HUD of the Player

    [Header("Health & Shield Bars")]
    public Image healthBar;
    public Image shieldBar;

    [Header("Icons")]
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
        ChangeStatusCommand.OnShield += ShieldIcon;
        ChangeStatusCommand.OnHp += HpIcon;
        ChangeStatusCommand.OnDmg += DmgIcon;
    }
    private void OnDisable()
    {
        ChangeStatusCommand.OnShield -= ShieldIcon;
        ChangeStatusCommand.OnHp -= HpIcon;
        ChangeStatusCommand.OnDmg -= DmgIcon;
    }
    private void Update()
    {
        //Updates the 2 Bars of the Player
        healthBar.fillAmount = (float)Player.Instance.currentHP / (float)Player.Instance.maxHP;
        shieldBar.fillAmount = (float)Player.Instance.shieldCurrentHp / (float)Player.Instance.shieldMaxHp;
    }
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
