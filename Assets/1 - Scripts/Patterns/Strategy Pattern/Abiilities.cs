using System;

//those are the class used when an ability is used (UseAbility) and when his effect is finished (ResetplayerStatus)
public class SpeedAbility : IAbility
{
    //increment the speed of the Player
    public void UseAbility()
    {
        Player.Instance.speed *= 2;
    }
    public void ResetPlayerStatus()
    {
        Player.Instance.speed = AbilityManager.Instance.baseSpeed;
    }
}
public class ShieldAbility : IAbility
{
    //Activate/Deactivate the Shield & sets the health of the Shield

    public static event Action OnShield; //an event invoked to update the Shield bar to show it proprely
    public void UseAbility()
    {
        AbilityManager.Instance.shieldArea.SetActive(true);
        Player.Instance.shieldCurrentHp = Player.Instance.maxShieldP;
        OnShield?.Invoke();
    }
    public void ResetPlayerStatus()
    {
        AbilityManager.Instance.shieldArea.SetActive(false);
        Player.Instance.shieldCurrentHp = 0;
        OnShield?.Invoke();
    }
}
public class MaxHPAbility : IAbility
{
    //refill the Health of the Player & make him invincible

    public static event Action OnMaxHp; //an event invoked to update the Health bar to refill it proprely
    public void UseAbility()
    {
        Player.Instance.currentHP = Player.Instance.maxHP;
        OnMaxHp?.Invoke();
        AbilityManager.Instance.invincible = true;
    }
    public void ResetPlayerStatus()
    {
        AbilityManager.Instance.invincible = false;
    }
}
public class DamageAbility : IAbility
{
    //Activate/Deactivate the Damage Area (the behavior is in the DamageArea script)
    public void UseAbility()
    {
        AbilityManager.Instance.damageArea.SetActive(true);
    }

    public void ResetPlayerStatus()
    {
        AbilityManager.Instance.damageArea.SetActive(false);
    }
}