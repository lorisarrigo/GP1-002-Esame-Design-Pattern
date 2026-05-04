using UnityEngine;
using System.Collections.Generic;
public class AbilityCommand : MonoBehaviour
{
    //the class that make the Command Pattern possible

    private Stack<ICommand> undoStack = new(); //the Stack where the Ability are saved, so it can be undone when called (on death)
    public static AbilityCommand Instance;
    /*it's recalled in:
     * ChangeStatusCommand to recall the AddCommand function (to store the ability picked Up)
     * Player to recall the UndoCommand function (to remove the last ability in the Stack)
     */

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
    }

    public void AddCommand(ICommand command) //add the Ability just pickedUp
    {
        undoStack.Push(command); 
        command.Execute();
    }

    public void UndoCommand() //remove the Last ability in the Stack
    {
        if (undoStack.Count <= 0) return;
        undoStack.Pop().Undo();
    }
}