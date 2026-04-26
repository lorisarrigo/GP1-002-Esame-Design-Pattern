using UnityEngine;
public class MaxHPAbility : IAbility
{
    //refill the Health of the Player
    public void UseAbility()
    {
        Player.Instance.currentHP = Player.Instance.maxHP;
    }
    public void ResetPlayerStatus()
    {
        Debug.Log("Bho ok?");
    }
}
