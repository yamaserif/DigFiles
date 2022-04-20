using DigFiles_interpreter.Business;
using DigFiles_interpreter.Extensions;
using DigFiles_interpreter.Interface;

namespace DigFiles_interpreter.Classes.Command
{
    public class LoopCommand : ICommand
    {
        public string Name { get; } = "loop";
        public string[] Args { get; set; }

        public RunData RunData { get; set; }

        public LoopCommand(string[] args,
                           RunData runData)
        {
            this.Args = args;
            this.RunData = runData;
        }

        public void Execute()
        {
            var arg1 = Commands.PreLoadVariableId(Args[0], this.RunData.Variables, this.RunData.Random);
            var arg2 = Commands.PreLoadVariableId(Args[1], this.RunData.Variables, this.RunData.Random);
            var arg3 = Args[2];

            while (this.RunData.Variables.GetVariable(arg1, this.RunData.Random) !=
                  this.RunData.Variables.GetVariable(arg2, this.RunData.Random))
            {
                var subRunData = new RunData(this.RunData.UserInput, this.RunData.Variables, this.RunData.Actions, this.RunData.Random);
                Run.Start(this.RunData.Actions[arg3], this.RunData);
            }
        }
    }
}
