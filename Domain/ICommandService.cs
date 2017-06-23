using System.Threading.Tasks;

namespace Domain
{
    public interface ICommandService
    {
        Task ExecuteCommand(ICommand command);
        Task Undo();
        Task Redo();
    }
}
