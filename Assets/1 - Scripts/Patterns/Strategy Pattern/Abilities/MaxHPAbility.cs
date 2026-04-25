using UnityEngine;

public class MaxHPAbility : IAbility
{

    public void UseAbility()
    {
        PlayerMovement.Instance.currentHP = PlayerMovement.Instance.maxHP;
    }
    public void ResetPlayerStatus()
    {
        Debug.Log("Bho ok?");
    }
}
