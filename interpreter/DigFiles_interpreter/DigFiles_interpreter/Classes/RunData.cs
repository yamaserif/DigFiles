using System;
using System.Collections.Generic;
using System.Text;

namespace DigFiles_interpreter.Classes
{
    public class RunData
    {
        public string CurrentPath { get; set; }
        public string UserInput { get; set; }

        public Dictionary<int, int> Variables { get; set; }
        public Dictionary<string, string> Actions { get; set; }

        public Random Random { get; set; }

        public RunData(string userInput,
                       Dictionary<int, int> variables,
                       Dictionary<string, string> actions,
                       Random random)
        {
            this.UserInput = userInput;
            this.Variables = variables;
            this.Actions = actions;
            this.Random = random;
        }
    }
}
