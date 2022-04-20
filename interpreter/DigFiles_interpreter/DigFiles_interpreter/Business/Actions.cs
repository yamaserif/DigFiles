using System.Collections.Generic;
using System.IO;

namespace DigFiles_interpreter.Business
{
    public static class Actions
    {
        public static void GetActions(string path, Dictionary<string, string> actions)
        {
            var dirs = Directory.GetDirectories(path);

            foreach (var dir in dirs)
            {
                actions.Add(GetActionId(dir), dir);

                GetActions(dir, actions);
            }

        }

        public static string GetActionId(string path)
        {
            var dirName = Path.GetFileName(path);
            var actionId = dirName.TrimStart('#')
                                    .Split('.')[0];

            return actionId;
        }
    }
}
