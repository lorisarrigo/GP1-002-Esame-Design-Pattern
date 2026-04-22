using UnityEngine;

public class AbilietiesManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            Debug.Log(gameObject.name);
            gameObject.SetActive(false);
        }
    }
}
