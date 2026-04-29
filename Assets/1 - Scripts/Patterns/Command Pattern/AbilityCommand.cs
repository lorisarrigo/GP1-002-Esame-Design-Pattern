using UnityEngine;
using System.Collections.Generic;
public class AbilityCommand : MonoBehaviour
{
    public static AbilityCommand Instance;

    private Stack<ICommand> undoStack = new();
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
    }

    public void AddCommand(ICommand command)
    {
        undoStack.Push(command); //Push = Add, Pop = remove
        command.Execute();
    }

    public void UndoCommand()
    {
        //if there is nothing in the history do nothing
        if (undoStack.Count <= 0)
            return;

        undoStack.Pop().Undo();
    }
}