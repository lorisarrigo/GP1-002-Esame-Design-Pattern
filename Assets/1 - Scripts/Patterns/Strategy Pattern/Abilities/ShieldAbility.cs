using UnityEngine;

public class ShieldAbility : IAbility
{
        public void UseAbility()
    {
        AbilityManager.Instance.shieldArea.SetActive(true);
        //AGGIUNGERE FILLBAR SHIELD
    }
    public void ResetPlayerStatus()
    {
        AbilityManager.Instance.shieldArea.SetActive(false);
    }
}