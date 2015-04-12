using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardHoard
{
    public interface ICommand
    {
        bool Execute();
    }

    public class ExitCommand : ICommand
    {
        public bool Execute()
        {
            return true;
        }
    }

    public class AddCommand : ICommand
    {
        public bool Execute()
        {
            Console.WriteLine("TEST");
            return false;
        }
    }

    public static class Parser
    {
        public static ICommand Parse(string commandString)
        {
            var commandParts = commandString.Split(' ').ToList();
            var commandName = commandParts[0];
            var args = commandParts.Skip(1).ToList(); // the arguments is after the command
            switch(commandName)
            {
                case "exit": return new ExitCommand();
                case "add": return new AddCommand();
                default: return null;
            }
        }
    }
}
