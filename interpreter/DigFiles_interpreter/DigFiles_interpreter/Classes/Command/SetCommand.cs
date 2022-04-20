using DigFiles_interpreter.Business;
using DigFiles_interpreter.Extensions;
using DigFiles_interpreter.Interface;

namespace DigFiles_interpreter.Classes.Command
{
    public class SetCommand : ICommand
    {
        public string Name { get; } = "set";
        public string[] Args { get; set; }

        public RunData RunData { get; set; }

        public SetCommand(string[] args,
                          RunData runData)
        {
            this.Args = args;
            this.RunData = runData;
        }

        public void Execute()
        {
            var arg1 = Commands.PreLoadVariableId(Args[0], this.RunData.Variables, this.RunData.Random);
            var arg2 = int.Parse(Args[1]);

            if (this.RunData.Variables.ContainsKey(arg1))
            {
                this.RunData.Variables[arg1] = arg2;
            }
            else
            {
                this.RunData.Variables.Add(arg1, arg2);
            }
        }
    }
}
