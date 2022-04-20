using DigFiles_interpreter.Business;
using DigFiles_interpreter.Extensions;
using DigFiles_interpreter.Interface;
using System;

namespace DigFiles_interpreter.Classes.Command
{
    public class OutCommand : ICommand
    {
        public string Name { get; } = "out";
        public string[] Args { get; set; }

        public RunData RunData { get; set; }

        public OutCommand(string[] args,
                          RunData runData)
        {
            this.Args = args;
            this.RunData = runData;
        }

        public void Execute()
        {
            var arg1 = Commands.PreLoadVariableId(Args[0], this.RunData.Variables, this.RunData.Random);

            var outByte = BitConverter.GetBytes(this.RunData.Variables.GetVariable(arg1, this.RunData.Random));
            var outString = System.Text.Encoding.UTF8.GetString(outByte);
            Console.Write(outString);
        }
    }
}
