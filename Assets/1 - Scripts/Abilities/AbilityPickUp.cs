using UnityEngine;
public class AbilityPickUp : MonoBehaviour
{
    //A class used in the GameOnjects of the PowerUps to make them deactivate when the Player Touches them
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log(gameObject.name);
            gameObject.SetActive(false);
        }
    }
}
