using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public interface ICommand
    {
        void Execute();
    }

    public class Receiver
    {
        public void Execute()
        {

        }
    }

    class ReceiverCommand : ICommand
    {
        Receiver Receiver { get; set; }

        public ReceiverCommand(Receiver receiver) 
        { 
            Receiver = receiver;
        }

        public void Execute()
        {
            Receiver.Execute();
        }
    }

    class Initiator
    {
        ICommand Command { get; set; }

        public void SetCommand(ICommand command)
        {
            Command = command;
        }

        public void ExecuteCommand() {
            Command.Execute();
        }
    }
}
