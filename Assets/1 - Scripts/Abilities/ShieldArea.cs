using UnityEngine;

public class ShieldArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EnemyBehavior proiettile = other.GetComponent<EnemyBehavior>(); //da sostiuire con lo script del proiettile
        if (proiettile != null)
        {
            Debug.Log("distrutto");
            gameObject.SetActive(proiettile.gameObject);
        }
    }
}
