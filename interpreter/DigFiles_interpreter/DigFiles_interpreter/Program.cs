using System;
using System.Collections.Generic;

using DigFiles_interpreter.Business;
using DigFiles_interpreter.Classes;

namespace DigFiles_interpreter
{
    class Program
    {
#if DEBUG
        public static string outData = string.Empty;
#endif
        static void Main(string[] args)
        {
            // 1st args: Program path
            // 2nd args: User input

            var baseDirPath = args[0];
            var userInput = string.Join(" ", args[1..]);

            var variables = new Dictionary<int, int>();
            var actions = new Dictionary<string, string>();
            var random = new Random();

            Actions.GetActions(baseDirPath, actions);

            var runData = new RunData(userInput, variables, actions, random);

            Run.Start(baseDirPath, runData);

#if DEBUG
            Console.WriteLine("output↓");
            Console.Write(Program.outData);
#endif
        }
    }
}
