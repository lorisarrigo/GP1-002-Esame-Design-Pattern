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
