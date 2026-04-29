using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    //Manages the element in the HUD of the Player

    //Health/Shield Bars
    public Image healthBar, shieldBar;

    //Abilities
    public GameObject speedIcon, shieldIcon, maxHpIcon, damageIcon;

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
