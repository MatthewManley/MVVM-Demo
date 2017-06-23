using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
