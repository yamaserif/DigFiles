using DigFiles_interpreter.Business;
using DigFiles_interpreter.Extensions;
using DigFiles_interpreter.Interface;
using System;
using System.Text;

namespace DigFiles_interpreter.Classes.Command
{
    public class InCommand : ICommand
    {
        public string Name { get; } = "in";
        public string[] Args { get; set; }

        public RunData RunData { get; set; }

        public InCommand(string[] args,
                         RunData runData)
        {
            this.Args = args;
            this.RunData = runData;
        }

        public void Execute()
        {
            var arg1 = Commands.PreLoadVariableId(Args[0], this.RunData.Variables, this.RunData.Random);

            var getVal = this.RunData.UserInput[0].ToString();
            this.RunData.UserInput = this.RunData.UserInput[1..];

            if (!this.RunData.Variables.ContainsKey(arg1))
            {
                this.RunData.Variables.Add(arg1, 0);
            }
            var bytes = Encoding.UTF8.GetBytes(getVal);
            this.RunData.Variables[arg1] = bytes[0];
        }
    }
}
