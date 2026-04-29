using UnityEngine;
public enum PowerUp
{
    Shield,
    maxHp,
    Dmg
}
public class AbilityPickUp : MonoBehaviour
{
    //A class used in the GameOnjects of the PowerUps to make them deactivate when the Player Touches them

    public PowerUp powerUp;
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            new ChangeStatusCommand(player.gameObject, gameObject, powerUp);
        }
    }
}
