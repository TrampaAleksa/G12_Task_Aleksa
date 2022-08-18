namespace DefaultNamespace
{
    public interface ICommand
    {
        void Execute();
        void SaveState();
        void Undo();
    }
}