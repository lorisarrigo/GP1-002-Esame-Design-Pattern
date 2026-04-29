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
