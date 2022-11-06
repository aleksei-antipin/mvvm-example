using System.Collections.Generic;

namespace Test.Infrastructure
{
    public class CompositeCommand : ICommand
    {
        private readonly List<ICommand> _commands;

        #region

        public CompositeCommand(params ICommand[] commands)
        {
            _commands = new List<ICommand>();
            foreach (var command in commands) _commands.Add(command);
        }

        #endregion

        public void Execute()
        {
            foreach (var command in _commands) command.Execute();
        }

        public void Undo()
        {
            foreach (var command in _commands) command.Undo();
        }
    }
}