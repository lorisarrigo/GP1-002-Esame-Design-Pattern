public interface ICommand 
{
    //an Interface used to manage the behaviour of the commang pattern
    public void Execute();
    public void Undo();
}
