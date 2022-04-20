using DigFiles_interpreter.Classes;
using DigFiles_interpreter.Classes.Command;
using DigFiles_interpreter.Extensions;
using DigFiles_interpreter.Interface;
using System;
using System.Collections.Generic;
using System.IO;

namespace DigFiles_interpreter.Business
{
    public static class Commands
    {
        public static string GetCommand(string path)
        {
            var dirName = Path.GetFileName(path);
            var command = dirName.Split('.')[0];

            return command;
        }

        public static void ExeCommand(string commandName,
                                      string[] args,
                                      RunData runData)
        {
            ICommand command;

            switch (commandName)
            {
                case "set":
                    command = new SetCommand(args, runData);
                    break;

                case "copy":
                    command = new CopyCommand(args, runData);
                    break;

                case "in":
                    command = new InCommand(args, runData);
                    break;

                case "out":
                    command = new OutCommand(args, runData);
                    break;

                case "loop":
                    command = new LoopCommand(args, runData);
                    break;

                case "add":
                    command = new AddCommand(args, runData);
                    break;

                default:
                    throw new DigFilesException("Undefined command.");
            }

            command.Execute();
        }

        public static int PreLoadVariableId(string variableId,
                                            Dictionary<int, int> variables,
                                            Random random)
        {
            if (variableId.StartsWith('*'))
            {
                var baseVariableId = variableId.TrimStart('*');

                return variables.GetVariable(int.Parse(baseVariableId), random);
            }
            else
            {
                return int.Parse(variableId);
            }
        }
    }
}
