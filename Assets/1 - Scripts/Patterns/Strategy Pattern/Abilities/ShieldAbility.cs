public class ShieldAbility : IAbility
{
    //Activate/Deactivate the Shield & sets the health of the Shield
    public void UseAbility()
    {
        AbilityManager.Instance.shieldArea.SetActive(true);
        Player.Instance.shieldCurrentHp = Player.Instance.shieldMaxHp;
    }
    public void ResetPlayerStatus()
    {
        AbilityManager.Instance.shieldArea.SetActive(false);
        Player.Instance.shieldCurrentHp = 0;
    }
}