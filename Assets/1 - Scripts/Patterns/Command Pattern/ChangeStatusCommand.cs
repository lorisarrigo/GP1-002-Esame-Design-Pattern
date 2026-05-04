using System;
using UnityEngine;
public class ChangeStatusCommand : ICommand
{
    //a class to manage what to do when the Player gets an Ability (the Execute function) and when it dies (Undo)

    GameObject Ability; //The PowerUp picked that will activate & deactivate;
    PowerUp type;
    bool Unlocked;
    public static event Action OnShield, OnHp, OnDmg;

    //saves the Ability and its type
    public ChangeStatusCommand(GameObject _Ability, PowerUp _type)
    {
        Ability = _Ability;
        type = _type;
        AbilityCommand.Instance.AddCommand(this);
    }
    //recalled when a Power Up is picked Up in the Ability command class
    public void Execute()
    {
        Ability.SetActive(false);
        Unlocked = true;
        AbilityCheck();
    }
    //recalled when the Player dies in the Ability command class
    public void Undo()
    {
        Ability.SetActive(true);
        Unlocked = false;
        AbilityCheck();
    }
    //check the Ability to Update
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
