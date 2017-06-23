using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class CommandService
    {
        private readonly ConcurrentStack<ICommand> _commandStack = new ConcurrentStack<ICommand>();
        private readonly ConcurrentStack<ICommand> _undoCommandStack = new ConcurrentStack<ICommand>();

        public async Task ExecuteComand(ICommand command)
        {
            _undoCommandStack.Clear();
            _commandStack.Push(command);
            await command.Do();
        }

        public async Task Undo()
        {
            ICommand command;
            var success = _commandStack.TryPop(out command);
            if (!success)
            {
                //TODO: Create custom exception
                throw new Exception();
            }
            await command.Undo();
            _undoCommandStack.Push(command);
        }

        public async Task Redo()
        {
            ICommand command;
            var success = _undoCommandStack.TryPop(out command);
            if (!success)
            {
                //TODO: Create custom exception
                throw new Exception();
            }
            await command.Do();
            _commandStack.Push(command);
        }
    }
}
