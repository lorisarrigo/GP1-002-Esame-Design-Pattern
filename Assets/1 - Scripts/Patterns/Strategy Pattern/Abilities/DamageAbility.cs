using UnityEngine;

public class DamageAbility : IAbility
{

    public void UseAbility()
    { 
        AbilityManager.Instance.damageArea.SetActive(true);
        //Collider[] overlap = Physics.OverlapSphere(PlayerMovement.Instance.transform.position, AbilityManager.Instance.damageArea.transform.lossyScale.x/2, AbilityManager.Instance.enemy);

        //if (overlap.Length > 0)
        //{
        //    Debug.Log("enemy entrato");
        //} 
        //non funziona in modo esatto perché il calcolo viene fatto solo ed esclusivamente nel momento in cui d'ho l'Input dello using
    }
    public void ResetPlayerStatus()
    {
        AbilityManager.Instance.damageArea.SetActive(false);
    }
}
