namespace Command
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class ModifyPrice
    {
        private readonly List<ICommand> commands;
        private ICommand comand;

        public ModifyPrice()
        {
            commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command) => comand = command;

        public void Invoke()
        { 
            commands.Add(comand);
            comand.ExecuteAction();
        }
    }
}
