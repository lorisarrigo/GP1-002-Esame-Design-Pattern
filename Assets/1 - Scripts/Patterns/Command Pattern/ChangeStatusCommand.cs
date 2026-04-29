using System;
using UnityEngine;
public class ChangeStatusCommand : ICommand
{
    GameObject Player; //GameObject da cambiare (è effettivamente così, serve?)
    GameObject Ability; //The PowerUp picked that will activate & deactivate;
    PowerUp type;
    bool Unlocked;
    public static event Action OnShield;
    public static event Action OnHp;
    public static event Action OnDmg;
    //ci salviamo l'oggetto da modificare, l'abilità ottenuta e quella da reimpostare
    public ChangeStatusCommand(GameObject player, GameObject _Ability, PowerUp _type)
    {
        Player = player;
        Ability = _Ability;
        type = _type;
        AbilityCommand.Instance.AddCommand(this);
    }
    public void Execute()
    {
        Ability.SetActive(false);
        Unlocked = true;
        AbilityCheck();
    }
    //utiliziamo l'abilità precedente per togliere l'ultima abilità
    public void Undo()
    {
        Ability.SetActive(true);
        Unlocked = false;
        AbilityCheck();
    }
    private void AbilityCheck()
    {
        switch (type)
        {
            case PowerUp.Shield:
                AbilityManager.Instance.ShieldCheck = Unlocked;
                OnShield?.Invoke();
                break;
            case PowerUp.maxHp:
                AbilityManager.Instance.MaxHpCheck = Unlocked;
                OnHp?.Invoke();
                break;
            case PowerUp.Dmg:
                AbilityManager.Instance.DamageCheck = Unlocked;
                OnDmg?.Invoke();
                break;
        }
    }
}
