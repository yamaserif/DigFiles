using DigFiles_interpreter.Classes;
using System;
using System.IO;

namespace DigFiles_interpreter.Business
{
    public static class Run
    {
        public static void Start(string path, RunData runData)
        {
            var dirs = Directory.GetDirectories(path);

            if(0 < dirs.Length)
            {
                var cmp = StringComparer.OrdinalIgnoreCase;
                Array.Sort(dirs, cmp);

                foreach (var dir in dirs)
                {
                    if (!Path.GetFileName(dir).StartsWith('#'))
                    {
                        Start(dir, runData);
                    }
                }
            }
            else
            {
                var files = Directory.GetFiles(path);

                if (0 < files.Length)
                {
#if DEBUG
                    Console.WriteLine();
#endif

                    var commandName = Commands.GetCommand(files[0]);

                    using (StreamReader sr = new StreamReader(files[0]))
                    {
                        var args = sr.ReadToEnd();
                        Commands.ExeCommand(commandName, args.Split(' '), runData);
#if DEBUG
                        Console.WriteLine($"\n↑{commandName} {args}: {files[0]}");
                        foreach (var var in runData.Variables)
                        {
                            Console.WriteLine($"{var.Key} : {var.Value}");
                        }
#endif
                    }
                }
            }
        }
    }
}
