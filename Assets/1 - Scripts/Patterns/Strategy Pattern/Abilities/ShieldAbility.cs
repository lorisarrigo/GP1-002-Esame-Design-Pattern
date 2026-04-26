public class ShieldAbility : IAbility
{
    //Activate/Deactivate the Shield & sets the health of the Shield
    public void UseAbility()
    {
        AbilityManager.Instance.shieldArea.SetActive(true);
        AbilityManager.Instance.shieldCurrentHp = AbilityManager.Instance.shieldMaxHp;
    }
    public void ResetPlayerStatus()
    {
        AbilityManager.Instance.shieldArea.SetActive(false);
        AbilityManager.Instance.shieldCurrentHp = 0;
    }
}