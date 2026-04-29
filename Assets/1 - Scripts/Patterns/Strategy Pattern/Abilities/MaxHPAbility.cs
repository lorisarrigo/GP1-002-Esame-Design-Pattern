using UnityEngine;
public class MaxHPAbility : IAbility
{
    //refill the Health of the Player
    public void UseAbility()
    {
        Player.Instance.currentHP = Player.Instance.maxHP;
        AbilityManager.Instance.invincible = true;
    }
    public void ResetPlayerStatus()
    {
        AbilityManager.Instance.invincible = false;
    }
}
