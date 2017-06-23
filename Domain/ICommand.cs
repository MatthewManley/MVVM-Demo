using System.Threading.Tasks;

namespace Domain
{
    public interface ICommand
    {
        Task Do();
        Task Undo();
    }
}
