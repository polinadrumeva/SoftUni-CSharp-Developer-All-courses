namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;


    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[]cmd = args.Split();
            string cmdName = cmd[0];
            string[] cmdArg = cmd.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();
            Type cmdType = assembly?.GetTypes().FirstOrDefault(t => t.Name == $"{cmdName}Command");

            if (cmdType == null)
            {
                throw new InvalidOperationException($"{cmdName} invalid name.");
            }

            object cmdInstance = Activator.CreateInstance(cmdType);

            MethodInfo executeMethod = cmdType.GetMethods().First(m => m.Name == "Execute");
            string result = (string)executeMethod.Invoke(cmdInstance, new object[] { cmdArg });

            return result;
        }
    }
}
