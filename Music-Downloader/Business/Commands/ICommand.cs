namespace Business.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
        void Redo();
    }
}