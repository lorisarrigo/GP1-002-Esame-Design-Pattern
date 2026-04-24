public class SpeedAbility : IAbility
{
    public void UseAbility()
    {
        PlayerMovement.Instance.speed *= 2;
    }
    public void ResetPlayerStatus()
    {
        PlayerMovement.Instance.speed = AbilityManager.Instance.baseSpeed;
    }
}
