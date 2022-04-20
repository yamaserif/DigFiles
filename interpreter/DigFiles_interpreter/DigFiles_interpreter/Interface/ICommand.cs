using DigFiles_interpreter.Classes;
using DigFiles_interpreter.Extensions;
using System;

namespace DigFiles_interpreter.Interface
{
    public interface ICommand
    {
        public string Name { get; }
        public string[] Args { get; set; }

        public RunData RunData { get; set; }

        public void Execute();
    }
}
