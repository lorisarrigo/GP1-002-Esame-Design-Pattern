public class ShieldAbility : IAbility
{
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