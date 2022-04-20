using System;
using System.Collections.Generic;
using System.Text;

namespace DigFiles_interpreter.Classes
{
    public class DigFilesException : Exception
    {
        public DigFilesException(string message) : base(message)
        {
        }
    }
}
