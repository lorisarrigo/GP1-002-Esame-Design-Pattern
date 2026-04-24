using UnityEngine;

public class DamageAbility : IAbility
{

    public void UseAbility()
    { 
        AbilityManager.Instance.damageArea.SetActive(true);
    }
    public void ResetPlayerStatus()
    {
        AbilityManager.Instance.damageArea.SetActive(false);
    }
}
