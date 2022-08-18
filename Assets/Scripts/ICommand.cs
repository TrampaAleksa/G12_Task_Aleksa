namespace DefaultNamespace
{
    public interface ICommand
    {
        void SaveState();
        void Execute();
        void Undo();
    }
}