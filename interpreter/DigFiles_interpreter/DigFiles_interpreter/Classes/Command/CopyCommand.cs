using DigFiles_interpreter.Business;
using DigFiles_interpreter.Extensions;
using DigFiles_interpreter.Interface;

namespace DigFiles_interpreter.Classes.Command
{
    public class CopyCommand : ICommand
    {
        public string Name { get; } = "copy";
        public string[] Args { get; set; }

        public RunData RunData { get; set; }

        public CopyCommand(string[] args,
                           RunData runData)
        {
            this.Args = args;
            this.RunData = runData;
        }

        public void Execute()
        {
            var arg1 = Commands.PreLoadVariableId(Args[0], this.RunData.Variables, this.RunData.Random);
            var arg2 = Commands.PreLoadVariableId(Args[1], this.RunData.Variables, this.RunData.Random);

            this.RunData.Variables[arg1] = this.RunData.Variables.GetVariable(arg2, this.RunData.Random);
        }
    }
}
